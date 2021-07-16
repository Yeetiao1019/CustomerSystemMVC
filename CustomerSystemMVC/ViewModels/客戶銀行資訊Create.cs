using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerSystemMVC.ViewModels
{
    public class 客戶銀行資訊Create
    {
        [Required]
        public int 客戶Id { get; set; }
        [Required]
        [StringLength(50,ErrorMessage ="輸入字元不超過 {1} 字")]
        public string 銀行名稱 { get; set; }
        [Required]
        public int 銀行代碼 { get; set; }
        [Required]
        public Nullable<int> 分行代碼 { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "輸入字元不超過 {1} 字")]
        public string 帳戶名稱 { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "輸入字元不超過 {1} 字")]
        public string 帳戶號碼 { get; set; }
    }
}