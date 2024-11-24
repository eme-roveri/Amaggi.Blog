using Amaggi.Blog.Application.DTO;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Amaggi.Blog.Application.Validation
{
    public class CredencialValidator : AbstractValidator<CredencialDTO>
    {
        public CredencialValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Informe o e-mail.")
                .EmailAddress().WithMessage("O e-mail fornecido é inválido.");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("Informe a senha.")
                .MinimumLength(6).WithMessage("Senha deve possuir no mínimo 6 caracteres.");
        }
    }
}
