using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Models
{
    public class CustomersViewModel
    {
        [DisplayName("ID")]
        public virtual int customer_id { get; set; }
        [DisplayName("Nome")]
        public virtual string name { get; set; }
        [DisplayName("E-mail")]
        public virtual string email { get; set; }
        [DisplayName("Contato Pessoal")]
        public virtual string contact_person { get; set; }
        [DisplayName("Endereço Postal")]
        public virtual string postal_address { get; set; }
        [DisplayName("Endereço Físico")]
        public virtual string physical_address { get; set; }
        [DisplayName("Telefone")]
        public virtual string contact_number { get; set; }
    }
}
