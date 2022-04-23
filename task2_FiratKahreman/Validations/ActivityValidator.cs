using FluentValidation;
using task2_FiratKahreman.Models;

namespace task2_FiratKahreman.Validations
{
    public class ActivityValidator : AbstractValidator<Activity>
    {
        public ActivityValidator()
        {
            RuleFor(a => a.ActivityName).NotEmpty().WithMessage("Aktivite ismi boş bırakılamaz!");
            RuleFor(a => a.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz!");
            RuleFor(a => a.Adress).NotEmpty().WithMessage("Adres boş bırakılamaz!");
            RuleFor(a => a.Limit).NotEmpty().WithMessage("Kontenjan boş bırakılamaz!");
            RuleFor(a => a.City).NotEmpty().WithMessage("Şehir boş bırakılamaz!");
            RuleFor(a => a.NeedTicket).NotEmpty().WithMessage("Etkinliğin biletli mi biletsiz mi olacağını seçiniz!");
        }
    }
}
