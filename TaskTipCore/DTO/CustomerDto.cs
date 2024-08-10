using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace TaskTipCore.DTO;

public class CustomerDto
{
    [DisplayName("نام")]
    [Required(ErrorMessage = "اجباری")]
    public string FName { get; set; }
    [DisplayName("نام خانوادگی")]
    [Required(ErrorMessage = "اجباری")]
    public string LName { get; set; }
    [DisplayName("تاریخ تولد")]
    
    [Required(ErrorMessage = "اجباری")]
    public DateTime DateOfBirth { get; set; }
    [DisplayName("تلفن همراه")]
    [Required(ErrorMessage = "اجباری")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "فقط عدد و باید 11 رقم باشد")]
    public string PhonNumber { get; set; }
    [DisplayName("پست الکترونیکی")]
    [EmailAddress(ErrorMessage = "فرمت ایمیل اشتباه است")]
    [Required(ErrorMessage = "اجباری")]
    public string Email { get; set; }
    [DisplayName("شماره حساب")]
    [Required(ErrorMessage = "اجباری")]
    public string BankAccuntNumber { get; set; }
}