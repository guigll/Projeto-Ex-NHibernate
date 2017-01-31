using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Domain.Model;

namespace Data.Context
{
    public class Conexao
    {
        private ISession Session;
        private ISessionFactory sessionFactory;
       


        public ISession Open()
        {

             sessionFactory = Fluently.Configure()
             .Database(MsSqlConfiguration.MsSql2012
               .ConnectionString(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CustomerRecordsDB;Integrated Security=True")
                           .ShowSql()
             )
            .Mappings(m =>
                       m.FluentMappings
                           .AddFromAssemblyOf<Customers>())
             .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                             .Create(false, false))
             .BuildSessionFactory();
            Session= sessionFactory.OpenSession();
            return Session;
        }

        public void Close()
        {
            if (Session != null && Session.IsOpen)
            {
                Session.Close();
                Session.Dispose();
            }
            if (sessionFactory != null && sessionFactory.IsClosed == false)
            {
                sessionFactory.Close();
                sessionFactory.Dispose();
            }
        }
    }
}
