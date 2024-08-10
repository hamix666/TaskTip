using System.Text;

namespace TaskTipCore.Utility;

public class OperationResult
{
    public string Message { get; set; }
    public OpreationResultStatus Status { get; set; }
    public string Title { get; set; }
    #region Error نمایش نتیجه خطا
    public static OperationResult Error()
    {
        return new OperationResult()
        {
            Status = OpreationResultStatus.Error,
            Message = "عملیات ناموفق",

        };
    }
    public static OperationResult Error(string message, string title = "")
    {
        StringBuilder stringBuilder = new StringBuilder();
        //stringBuilder.AppendLine("عملیات ناموفق");
        stringBuilder.AppendLine(message);
        return new OperationResult()
        {
            Status = OpreationResultStatus.Error,
            Message = stringBuilder.ToString(),
            Title = title
        };
    }

    #endregion

    public static OperationResult Not(string message, string title = "")
    {
        return new OperationResult()
        {
            Status = OpreationResultStatus.Not,
            Message = message,
            Title = title
        };
    }
    #region NotFound نمایش یافت نشد
    public static OperationResult NotFound(string message, string title = "")
    {
        return new OperationResult()
        {
            Status = OpreationResultStatus.NotFound,
            Message = message,

        };
    }
    public static OperationResult NotFound()
    {
        return new OperationResult()
        {
            Status = OpreationResultStatus.NotFound,
            Message = "اطلاعات یافت نشد"

        };
    }

    #endregion

    #region Success نمایش عملیات موفق
    public static OperationResult Success(string message)
    {
        return new OperationResult()
        {
            Status = OpreationResultStatus.Success,
            Message = message

        };
    }
    public static OperationResult Success()
    {
        return new OperationResult()
        {
            Status = OpreationResultStatus.Success,
            Message = "عملیات با موفقیت انجام شد"

        };
    }

    #endregion

    /// <summary>
    /// انواع خطا ها
    /// </summary>
    public enum OpreationResultStatus
    {
        Error = 10,
        Success = 200,
        NotFound = 400,
        Not = 404
    }
}