using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Customers
    {
        public virtual int customer_id { get; set; }
        public virtual string name { get; set; }
        public virtual string email { get; set; }
        public virtual string contact_person { get; set; }
        public virtual string postal_address { get; set; }
        public virtual string physical_address { get; set; }
        public virtual string contact_number { get; set; }
    }
}
