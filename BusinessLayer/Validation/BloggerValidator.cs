using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class BloggerValidator:AbstractValidator<Blogger>
    {
        public BloggerValidator()
        {
            RuleFor(x => x.BloggerName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez");
            RuleFor(x => x.BloggerMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.BloggerPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.BloggerName).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
            RuleFor(x => x.BloggerName).MaximumLength(50).WithMessage("Veri girişi en fazla 50 karakter olmalıdır");
            
        }
    }
}
