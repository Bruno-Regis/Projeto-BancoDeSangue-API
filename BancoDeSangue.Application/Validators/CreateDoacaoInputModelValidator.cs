using BancoDeSangue.Application.Models.InputModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Validators
{
    public class CreateDoacaoInputModelValidator : AbstractValidator<CreateDoacaoInputModel>
    {
        public CreateDoacaoInputModelValidator()
        {
            RuleFor(x => x.DoadorId)
                .NotEmpty().WithMessage("O ID do doador é obrigatório.");

            RuleFor(x => x.DataDoacao)
                .NotEmpty().WithMessage("A data da doação é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("A data da doação deve ser no passado.");

            RuleFor(x => x.QuantidadeMl)
                .NotEmpty().WithMessage("A quantidade em ml é obrigatória.")
                .Must(x => x > 420 && x < 470)
                    .WithMessage("A quantidade em ml deve ser maior que zero.");
        }
    }
}
