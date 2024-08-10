using TaskTipCore.DTO;
using TaskTipCore.Utility;

namespace TaskTipCore.Services.Customer;

public interface ICustomerServices:IRepositoryBase<TaskTipDataLayer.Entity.Customer>
{
    OperationResult Create(CustomerDto customerDto);
    OperationResult Update(Guid ID,CustomerDto customerDto);
    
}