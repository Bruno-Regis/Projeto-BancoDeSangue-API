using BancoDeSangue.Application.Models.InputModels;
using FluentValidation;

namespace BancoDeSangue.Application.Validators
{
    public class CreateDoadorInputModelValidator : AbstractValidator<CreateDoadorInputModel>
    {
        public CreateDoadorInputModelValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(50).WithMessage("O nome deve ter no máximo 50 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail deve ser válido.")
                .MaximumLength(100).WithMessage("O e-mail deve ter no máximo 100 caracteres.");

            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser no passado.");

            RuleFor(x => x.Genero)
                .NotEmpty() .WithMessage("O gênero é obrigatório.")
                .IsInEnum().WithMessage("O gênero é inválido.");

            RuleFor(x => x.TipoSanguineo)
                .NotEmpty() .WithMessage("O tipo sanguíneo é obrigatório.")
                .IsInEnum().WithMessage("O tipo sanguíneo é inválido.");

            RuleFor(x => x.FatorRh)
                .NotEmpty() .WithMessage("O fator Rh é obrigatório.")
                .IsInEnum().WithMessage("O fator Rh é inválido.");
        }   
    }
}
