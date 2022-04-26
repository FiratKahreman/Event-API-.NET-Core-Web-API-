using FluentValidation;
using System.Text.RegularExpressions;
using task2_FiratKahreman.Models;

namespace task2_FiratKahreman.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Lütfen isminizi giriniz");
            RuleFor(a => a.Surname).NotEmpty().WithMessage("Lütfen soyadınızı giriniz");
            RuleFor(a => a.Mail)
                .EmailAddress().WithMessage("Lütfen mail adresinizi giriniz").When(a => !string.IsNullOrEmpty(a.Mail));
            RuleFor(a => a.Password).NotEmpty()
                .Must(IsPasswordValid)
                .WithMessage("Şifre en az 8 karakter, harf ve sayı içermelidir!");
            RuleFor(a => a.RePassword)
                .Equal(a => a.Password).WithMessage("Girilen şifreler aynı olmalıdır!");            
        }
        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return regex.IsMatch(arg);
        }
    }
}
