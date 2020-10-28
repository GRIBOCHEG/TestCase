using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace testCase.Models
{
    public class ISBNAttribute : ValidationAttribute
    {
        public ISBNAttribute()
        {            }

        public string GetErrorMessage(string isbn) =>
            $"ISBN code must be valid {isbn}.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var book = (Book)validationContext.ObjectInstance;
            var isbn = (string)value;
            if (string.IsNullOrWhiteSpace(isbn))
            {
                return new ValidationResult(GetErrorMessage(isbn));
            }
            if (isbn.Contains('-')) 
            {
                isbn = isbn.Replace("-", "");
            }
            if (!TryValidate(isbn))
            {
                return new ValidationResult(GetErrorMessage(isbn));
            }
            return ValidationResult.Success;
        }

        public bool TryValidate(string isbn)
        {
            bool result = false;
            switch (isbn.Length)
            {
                case 10: result = IsValidIsbn10(isbn); break;
                case 13: result = IsValidIsbn13(isbn); break;
            }
            return result;
        }

        private bool IsValidIsbn10(string isbn10)
        {
            var codelen = isbn10.Length - 1; // isbn len wo check digit

            if (isbn10.Take(codelen).Any(c => !char.IsDigit(c)))
            {
                return false;
            }

            int sum = 0;
            for (int i = 0; i < codelen; i++)
            {
                sum += (i + 1) * (isbn10[i] - '0');
            }

            int remainder = sum % 11;
            if (remainder == 10)
            {
                return isbn10.Last() == 'X';
            }
            else
            {
                return isbn10.Last() == (char)('0' + remainder);
            }
        }

        private bool IsValidIsbn13(string isbn13)
        {
            int sum = 0;
            for (var i = 0; i < isbn13.Length; i++)
            {
                if (!char.IsDigit(isbn13[i]))
                {
                    return false;
                }
                sum += (isbn13[i] - '0') * (i % 2 == 0 ? 1 : 3);
            }
            return sum % 10 == 0;
        }
    }
}