using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerSystemMVC.ViewModels
{
    public class 客戶資料Edit
    {
        [Required]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 {1} 個字元")]
        public string 客戶名稱 { get; set; }
        [StringLength(8, ErrorMessage = "欄位長度不得大於 {1} 個字元")]
        [MinLength(8, ErrorMessage = "請輸入 {1} 個字元")]
        public string 統一編號 { get; set; }
        [StringLength(50, ErrorMessage = "欄位長度不得大於 {1} 個字元")]
        public string 電話 { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 {1} 個字元")]
        public string 傳真 { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "欄位長度不得大於 {1} 個字元")]
        public string 地址 { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "欄位長度不得大於 {1} 個字元")]
        public string Email { get; set; }
    }
}