using System.ComponentModel.DataAnnotations;

namespace CustomersWebSite.ViewModels
{
    public class ContactViewModel:IValidatableObject
    {
        [Required(ErrorMessage = "姓名欄位未填寫")]
        [StringLength(maximumLength: 8, MinimumLength = 5, ErrorMessage = "姓名長度不正確")]
        [Display(Name="姓名")]
        public string? Name {  get; set; }

        //[Required(ErrorMessage = "電子郵件欄位未填寫")]
        [Display(Name = "電子郵件")]
        [EmailAddress(ErrorMessage ="電子郵件格式錯誤")]
        public string? Email {  get; set; }

        [Display(Name = "連絡電話")] 
        public string? Phone {  get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) //可列舉類型，通常return都做在if裡面，不要直接return
        {
            if(string.IsNullOrEmpty(Email)&& string.IsNullOrEmpty(Phone))
            {
                yield return new ValidationResult("電子郵件和電話號碼必須至少填寫一個欄位");

                //yield return new ValidationResult("電子郵件和電話號碼必須至少填寫一個欄位", new string[] { "Email", "" });
            }
        }
    }
}