using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EntityAbstractions.Entities;
using EntityManagerAbstractions.EntityManagers;
using EntitiyChangeLog;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;
using DataServiceAbstraction.DataService;

public class ChangeLogBehaviour<T,S> : IInterceptionBehavior where T : AbstractEntity where S : AbstractEntityChangeLog
{

    IDataService<T> _EntityDataService;
    IUnityContainer _IOCContainer;
    IDataService<S> _EntityChangeLogDataService;

    public ChangeLogBehaviour
        (
            IDataService<T> EntityDataService,
            IDataService<S> EntityChangeLogDataService,
            IUnityContainer IOCContainer
        )
    {
        _EntityDataService = EntityDataService;
        _IOCContainer = IOCContainer;
        _EntityChangeLogDataService = EntityChangeLogDataService;
    }

    public IEnumerable<Type> GetRequiredInterfaces()
    {
        return Type.EmptyTypes;
    }
    public bool WillExecute
    {
        get { return true; }
    }


    public  IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
    {


        if (input.MethodBase.Name == "UpdateAsync")
        {
            try
            {

                var task = Task.Run(async () => await _EntityDataService.GetAsync(((T)input.Arguments["Entity"]).id));


                T currentEntityObject = task.GetAwaiter().GetResult();


                AbstractEntityChangeLog abstractEntityChangeLog = _IOCContainer.Resolve<AbstractEntityChangeLog>();

                List<string> changedPropertiesList = GetChangedProperties(currentEntityObject, ((T)input.Arguments["Entity"]));

                S abstractOrderChange;
                abstractOrderChange = _IOCContainer.Resolve<S>();


                foreach (var propertyName in changedPropertiesList)
                {
                    abstractOrderChange.id = Guid.NewGuid().ToString();
                    abstractOrderChange.EntityName = typeof(T).Name;
                    abstractOrderChange.EntityId = abstractOrderChange.id;
                    abstractOrderChange.FieldName = propertyName;
                    abstractOrderChange.NewValue = GetPropValue((T)input.Arguments["Entity"], propertyName).ToString();
                    abstractOrderChange.OldValue = GetPropValue(currentEntityObject, propertyName).ToString();
                    abstractOrderChange.ChangeDate = DateTime.Now;
                    _EntityChangeLogDataService.InsertAsync(abstractOrderChange);
                }
            }
            catch (Exception ex)
            {
            }

            }


        var methodReturn = getNext().Invoke(input, getNext);

        return methodReturn;
    }

    public static object GetPropValue(object src, string propName)
    {
        return src.GetType().GetProperty(propName).GetValue(src, null);
    }
    public static List<string> GetChangedProperties(Object A, Object B)
    {
        if (A.GetType() != B.GetType())
        {
            throw new System.InvalidOperationException("Objects of different Type");
        }
        List<string> changedProperties = ElaborateChangedProperties(A.GetType().GetProperties(), B.GetType().GetProperties(), A, B);
        return changedProperties;
    }


    public static List<string> ElaborateChangedProperties(PropertyInfo[] pA, PropertyInfo[] pB, Object A, Object B)
    {
        List<string> changedProperties = new List<string>();
        foreach (PropertyInfo info in pA)
        {
            object propValueA = info.GetValue(A, null);
            object propValueB = info.GetValue(B, null);
            if (propValueA.ToString() != propValueB.ToString())
            {
                changedProperties.Add(info.Name);
            }
        }
        return changedProperties;
    }
}