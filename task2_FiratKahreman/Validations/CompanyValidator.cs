using FluentValidation;
using task2_FiratKahreman.Models;

namespace task2_FiratKahreman.Validations
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(a => a.CompanyName).NotEmpty().WithMessage("Şirket ismi boş bırakılamaz!");
            RuleFor(a => a.CompanyWeb).NotEmpty().WithMessage("Şirket web adresi boş bırakılamaz!");
        }
    }
}
