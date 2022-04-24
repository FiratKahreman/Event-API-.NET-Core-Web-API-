using FluentValidation;
using System.Text.RegularExpressions;
using task2_FiratKahreman.Models;

namespace task2_FiratKahreman.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("İsim boş bırakılamaz!");
            RuleFor(a => a.Surname).NotEmpty().WithMessage("İsim boş bırakılamaz!");
            RuleFor(a => a.Mail)
                .EmailAddress().WithMessage("Mail boş bırakılamaz!").When(a => !string.IsNullOrEmpty(a.Mail));
            RuleFor(a => a.Password).NotEmpty()
                .Must(IsPasswordValid)
                .WithMessage("Şifre en az 8 karakter, harf ve sayı içermelidir!");
            RuleFor(a => a.RePassword)
                .Equal(a => a.RePassword).WithMessage("Girilen şifreler aynı olmalıdır!");
            RuleFor(a => a.Role).NotEmpty().WithMessage("Lütfen üye tipini seçiniz.");

            
        }
        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return regex.IsMatch(arg);
        }
    }
}
