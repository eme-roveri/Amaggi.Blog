using Amaggi.Blog.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaggi.Blog.Application.Validation
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(p => p.Titulo)
                .NotEmpty().WithMessage("Informe o título do Post.")
                .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres.");

            RuleFor(p => p.Conteudo)
                .NotEmpty().WithMessage("Informe o conteúdo do Post.");
        }
    }
}
