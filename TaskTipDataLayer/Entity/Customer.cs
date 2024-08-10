using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskTipDataLayer.Entity;

public class Customer :ModelObject
{
    [DisplayName("نام")]
    public string FName { get; set; }
    [DisplayName("نام خانوادگی")]
    public string LName { get; set; }
    [DisplayName("تاریخ تولد")]
    public DateTime DateOfBirth { get; set; }
    [DisplayName("تلفن همراه")]
    public string PhonNumber { get; set; }
    [DisplayName("پست الکترونیکی")]
    public string Email { get; set; }
    [DisplayName("شماره حساب")]
    public string BankAccuntNumber { get; set; }
   
}

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        
        builder.HasIndex(x => new { x.FName, x.LName, x.DateOfBirth }).IsUnique();
        builder.Property(x => x.PhonNumber).HasMaxLength(11).IsRequired();
        builder.HasIndex(x => x.Email).IsUnique();
    }
}