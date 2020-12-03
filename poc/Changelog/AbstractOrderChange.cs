using System;
using System.Collections.Generic;
using System.Text;
using EntityAbstractions.Entities;
namespace EntitiyChangeLog
{
    public class AbstractEntityChangeLog : AbstractEntity
    {
        public virtual string EntityName { get; set; }
        public virtual string EntityId { get; set; }
        public virtual string FieldName { get; set; }
        public virtual string OldValue { get; set; }
        public virtual string NewValue { get; set; }
        public virtual DateTime ChangeDate { get; set; }
    }
}