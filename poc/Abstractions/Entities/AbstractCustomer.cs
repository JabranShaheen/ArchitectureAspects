using System;
using System.Collections.Generic;
using System.Text;

namespace EntityAbstractions.Entities
{
    public class AbstractCustomer : AbstractEntity
    {

        public virtual string name { get; set; }
        public virtual string address { get; set; }
        public virtual string phoneNumber { get; set; }

    }
}
