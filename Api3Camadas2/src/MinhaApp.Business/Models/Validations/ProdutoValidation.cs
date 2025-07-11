﻿using FluentValidation;

namespace MinhaApp.Business.Models.Validations
{
	public class ProdutoValidation : AbstractValidator<Produto>
	{
		public ProdutoValidation()
		{
			RuleFor(p => p.Nome)
				.NotEmpty()
					.WithMessage("O campo {PropertyName} precisa ser fornecido")
				.Length(2, 200)
					.WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

			RuleFor(p => p.Valor)
				.GreaterThan(0)
					.WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

			RuleFor(p => p.DataCadastro)
				.LessThan(DateTime.Now)
					.WithMessage("O campo {PropertyName} precisa ser menor que a data atual");

		}
	}
}
