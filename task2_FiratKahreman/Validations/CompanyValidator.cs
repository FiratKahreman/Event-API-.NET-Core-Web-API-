using FluentValidation;
using System.Text.RegularExpressions;
using task2_FiratKahreman.Models;

namespace task2_FiratKahreman.Validations
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(a => a.CompanyName).NotEmpty().WithMessage("Lütfen şirket ismini giriniz");
            RuleFor(a => a.CompanyWeb).NotEmpty().WithMessage("Lütfen şirket web sitesi adresini giriniz");
            RuleFor(a => a.CompanyMail)
                .EmailAddress().WithMessage("Lütfen şirket iletişim mail adresini giriniz").When(a => !string.IsNullOrEmpty(a.CompanyMail));
            RuleFor(a => a.CompanyPassword).NotEmpty()
                .Must(IsPasswordValid)
                .WithMessage("Şifre en az 8 karakter, harf ve sayı içermelidir!");
            RuleFor(a => a.CompanyRePassword)
                .Equal(a => a.CompanyPassword).WithMessage("Girilen şifreler aynı olmalıdır!");
        }

        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return regex.IsMatch(arg);
        }
    }
}
