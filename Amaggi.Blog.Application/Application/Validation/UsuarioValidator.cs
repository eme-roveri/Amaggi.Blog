using Amaggi.Blog.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaggi.Blog.Application.Validation
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator() 
        {
            RuleFor(u => u.Nome)
                .NotEmpty()
                .WithMessage("Infome o nome do usuário.");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Informe o e-mail do usuário");

            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("O e-mail informado está em um formato incorreto");
            
            RuleFor(u => u.Senha)
                .NotEmpty()
                .WithMessage("Informe a senha do usuário.");

            //RuleFor(x => x.ConfirmacaoSenha)
            //    .NotEmpty().WithMessage("Confirme a senha informada");

            //RuleFor(x => x)
            //    .Must(x => x.Senha == x.ConfirmacaoSenha)
            //    .WithMessage("As senhas informadas não são iguais");
        }
    }
}
