using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CustomerSystemMVC.ValidateAttributes
{
    public class PhoneNumberAttribute : RegularExpressionAttribute
    {
        public PhoneNumberAttribute() : base(@"\d{4}-\d{6}")
        {
            ErrorMessage = "請輸入正確的手機號碼 (09xx-xxxxxx)";
        }
    }
}