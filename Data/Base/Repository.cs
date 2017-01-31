using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using NHibernate;
using NHibernate.Linq;

namespace Data.Base
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {

        protected readonly Conexao ctx = new Conexao();
        private ISession session;

        public void Dispose()
        {
            ctx.Close();
        }

        public void Salvar(T model)
        {
            using (session = ctx.Open())
            {
                using (session.BeginTransaction())
                {
                    session.Save(model);
                    session.Transaction.Commit();
                }
                
            }
        }
    

        public void Editar(T model)
        {
            using (session = ctx.Open())
            {
                using (session.BeginTransaction())
                {
                    session.SaveOrUpdate(model);
                    session.Transaction.Commit();
                }
                
            }
        }

        

        public void Deletar(T model)
        {
            using (session = ctx.Open())
            {
                using(session.BeginTransaction())
                {
                    session.Delete(model);
                    session.Transaction.Commit();
                }
            }
        }

        public T ConsultarPorId(object key)
        {
            using (session = ctx.Open())
            {
                var obj = session.Get<T>(key);
                return obj;
            }
        }

        public List<T> ConsultarTodos()
        {
            using (session = ctx.Open())
            {
                var obj = session.Query<T>().ToList();
                return obj;
            }
        }

        public List<T> ConsultarTodos(Expression<Func<T, bool>> Where)
        {
            using (session = ctx.Open())
            {
                var obj = session.Query<T>().Where(Where).ToList();
                return obj;
            }
        }
    }
}
