using democrud.Enums;
using democrud.models;
using FluentValidation;

namespace democrud.Models
{
    public class FuncionarioModelValidator : AbstractValidator<FuncionarioModel>
    {
        public FuncionarioModelValidator()
        {
            RuleFor(funcionario => funcionario.Id).NotEmpty().WithMessage("O ID do funcionário é obrigátorio");
            RuleFor(funcionario => funcionario.Nome).NotEmpty().WithMessage("O Nome do funcionário é obrigátorio");
            RuleFor(funcionario => funcionario.Sobrenome).NotEmpty().WithMessage("O Sobrenome do funcionário é obrigátorio");
            RuleFor(funcionario => funcionario.Departamento).NotEmpty().WithMessage("O Departamento do funcionário é obrigátorio");
            // etc..
        }
    }
}
