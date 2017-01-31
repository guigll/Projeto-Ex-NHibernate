using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public interface IRepository<T> 
    {
        void Salvar(T model);
        void Editar(T model);
        void Deletar(T model);
        T ConsultarPorId(object Key);
        List<T> ConsultarTodos();
        List<T> ConsultarTodos(Expression<Func<T, bool>> Where);
    }
}
