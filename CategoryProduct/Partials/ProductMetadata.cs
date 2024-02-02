using System.ComponentModel.DataAnnotations;

namespace CategoryProduct.Models
{
    internal class ProductMetadata
    {
        [Required(ErrorMessage ="名稱未填寫")]
        [StringLength(40)]
        [Display(Name = "商品名稱")]
        public string ProductName { get; set; } = null!;

        [Display(Name ="商品單價")]
        [DisplayFormat(DataFormatString="{0:C}")] 
        public decimal? UnitPrice { get; set; }

        [Display(Name ="訂購單位")]
        [Range(1,100, ErrorMessage= "{0}必須介於{1}~{2}之間")]
        public short? UnitsOnOrder { get; set; }
    }
}