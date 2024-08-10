using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TaskTipCore.Utility;
using TaskTipDataLayer.Context;
using TaskTipDataLayer.Entity;

namespace TaskTipCore.Services;

public class RepositoryBase<T>:IRepositoryBase<T> where T : ModelObject,new()
{
    protected TaskTipContext _TaskTipContext;
    public RepositoryBase(TaskTipContext _context)
    {
        _TaskTipContext= _context;
    }

    

    public T FindByID(Guid id) => _TaskTipContext.Set<T>().Where(x => x.ID == id).FirstOrDefault();

    public IQueryable<T> FindAll() => _TaskTipContext.Set<T>().AsNoTracking();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
        _TaskTipContext.Set<T>().Where(expression).AsNoTracking();

    public OperationResult Create(T entity)
    {
        try
        {
            
            _TaskTipContext.Set<T>().Add(entity);
            _TaskTipContext.SaveChanges();
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }

    public OperationResult Update(T entity)
    {
        try
        {
            _TaskTipContext.Set<T>().Update(entity);
            _TaskTipContext.SaveChanges();
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }

    public OperationResult Delete(T entity)
    {
        try
        {
            _TaskTipContext.Set<T>().Remove(entity);
            _TaskTipContext.SaveChanges();
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}