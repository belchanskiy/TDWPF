using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace TeachersDiaryWPF
{
    public class AuthLoginValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string AuthLoginVal = value as string;
            if (AuthLoginVal == null || AuthLoginVal == "")
                return new ValidationResult(false, "Введите логин");

            if (AuthLoginVal.Length < 4)
                return new ValidationResult(false, "Логин состоит как минимум из 4 символов");

            return new ValidationResult(true, null);
        }
    }

    public class AuthPasswordValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string AuthPasswordVal = value as string;
            if (AuthPasswordVal == null || AuthPasswordVal == "")
                return new ValidationResult(false, "Введите пароль");

            if (AuthPasswordVal.Length < 6)
                return new ValidationResult(false, "ПаролЪ долженЪ состоять как минимум из 6 символовЪ");

            return new ValidationResult(true, null);
        }
    }
}
