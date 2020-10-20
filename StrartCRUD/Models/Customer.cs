using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StrartCRUD.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Nhap vao ten")]
        [StringLength(6, ErrorMessage = "Ten phai it hon hoac bang 6 ky tu")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nhap dia chi")]
        [StringLength(20, ErrorMessage = "Dia chi phao it hon hoac bang 20 ky tu")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phai nhap vao so dien thoai")]
        [Display(Name = "Dien thoai")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "So dien thoai nay khong dung dunh dang")]
        public string Mobileno { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Nhap vao ngay sinh")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [CustomValidationAttributeDemo.ValidBirthDate(ErrorMessage = "Ngay sinh khong the lon hon ngay hien tai")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Nhap vao email")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Dia chi mail khong hop le")]
        public string EmailID { get; set; }

        public List<Customer> ShowallCustomer { get; set; }
    }
}