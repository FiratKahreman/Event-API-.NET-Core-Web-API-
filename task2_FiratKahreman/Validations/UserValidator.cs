using FluentValidation;
using task2_FiratKahreman.Models;

namespace task2_FiratKahreman.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("İsim boş bırakılamaz!");
            RuleFor(a => a.Surname).NotEmpty().WithMessage("İsim boş bırakılamaz!");
            RuleFor(a => a.Mail).NotEmpty().WithMessage("Mail boş bırakılamaz!")
                .EmailAddress();
            RuleFor(a => a.Password).NotEmpty().MinimumLength(8)//!!!!!!!!!!!!!!!;
            RuleFor(a => a.RePassword).Equal(a => a.RePassword).WithMessage("Girilen şifreler aynı olmalıdır!");
            RuleFor(a => a.Role).NotEmpty().WithMessage("Lütfen üye tipini seçiniz.");
        }
    }
}
