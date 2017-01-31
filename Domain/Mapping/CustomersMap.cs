using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    class CustomersMap : ClassMap<Customers>
    {
        public CustomersMap()
        {
            Id(x => x.customer_id);
            Map(x => x.name);
            Map(x => x.email);
            Map(x => x.contact_person);
            Map(x => x.postal_address);
            Map(x => x.physical_address);
            Map(x => x.contact_number);
        }
    }
}
