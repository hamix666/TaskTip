using System.Linq.Expressions;
using TaskTipCore.Utility;

namespace TaskTipCore.Services;

public interface IRepositoryBase<T>
{
    T FindByID(Guid id);
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T,bool>>  condition);
    OperationResult Create(T entity);
    OperationResult Update(T entity);
    OperationResult Delete(T entity);
   
}