using TaskTipCore.DTO;
using TaskTipCore.Utility;
using TaskTipDataLayer.Context;

namespace TaskTipCore.Services.Customer;

public class CustomerServices:RepositoryBase<TaskTipDataLayer.Entity.Customer>,ICustomerServices
{
    public CustomerServices(TaskTipContext _context) : base(_context)
    {
    }

    public OperationResult Create(CustomerDto customerDto)
    {
        OperationResult result = new OperationResult();
        var _customer = CommonExtention.Mapto<CustomerDto, TaskTipDataLayer.Entity.Customer>(customerDto);
        if (_TaskTipContext.Customers_List.Any(c => c.Email == _customer.Email))
        {
           result= OperationResult.Error("ایمیل در دیتابیس وجود دارد ","مورد تکراری");
           result.Status = OperationResult.OpreationResultStatus.Error;
           return result;
        }

        if (_TaskTipContext.Customers_List.Any(c =>
                c.FName == _customer.FName && c.LName == _customer.LName && c.DateOfBirth == _customer.DateOfBirth))
        {
            result=OperationResult.Error("این شخص با این اطلاعات تکراری میباشد","مورد تکراری");
            result.Status = OperationResult.OpreationResultStatus.Error;
            return result;
        }

        Create(_customer);
        result.Status = OperationResult.OpreationResultStatus.Success;
        result.Message = "با موفقیت ثبت شد" + "شماره آیدی :  " + _customer.ID;
        result.Title = "ثبت";
        return result;
    }

    public OperationResult Update(Guid ID,CustomerDto customerDto)
    {
        OperationResult result = new OperationResult();
        if (customerDto == null)
        {
            result.Status = OperationResult.OpreationResultStatus.NotFound;
            return result;
        }

        var _customer = CommonExtention.Mapto<CustomerDto, TaskTipDataLayer.Entity.Customer>(customerDto);
        _customer.ID = ID;
        if (!_TaskTipContext.Customers_List.Any(c => c.ID != ID))
        {
            result = OperationResult.Error("یافت نشد");
            result.Status = OperationResult.OpreationResultStatus.NotFound;
            return result;
        }
        if (_TaskTipContext.Customers_List.Any(c => c.Email == _customer.Email && c.ID !=_customer.ID))
        {
            result = OperationResult.Error("ایمیل در دیتابیس وجود دارد ", "مورد تکراری");
            result.Status = OperationResult.OpreationResultStatus.Error;
            return result;
        }
        if (_TaskTipContext.Customers_List.Any(c =>
                c.FName == _customer.FName && c.LName == _customer.LName && c.DateOfBirth == _customer.DateOfBirth && c.ID !=_customer.ID))
        {
            result = OperationResult.Error("این شخص با این اطلاعات تکراری میباشد", "مورد تکراری");
            result.Status = OperationResult.OpreationResultStatus.Error;
            return result;
        }

        Update(_customer);
        result.Status = OperationResult.OpreationResultStatus.Success;
        result.Message = "با موفقیت ویرایش شد" + "شماره آیدی : " + _customer.ID;
        result.Title = "ثبت";
        return result;

    }

    
}