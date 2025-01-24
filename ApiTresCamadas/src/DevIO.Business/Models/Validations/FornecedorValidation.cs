﻿
using DevIO.Business.Models.Validations.Documentos;
using FluentValidation;
using System.Drawing;

namespace DevIO.Business.Models.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLenght} caracteres");

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaFisica, () =>
            {
                RuleFor(c => c.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("O campo {PropertyName} precisa ter {ComparisonValue} caracteres, e foi fornecido {PropertyValue}");

                RuleFor(f => CpfValidacao.Validar(f.Documento)).Equal(true)
                    .WithMessage("O documento fornecido é inválido");
            });

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
            {
                RuleFor(c => c.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
                    .WithMessage("O campo {PropertyName} precisa ter {ComparisonValue} caracteres, e foi fornecido {PropertyValue}");

                RuleFor(f => CnpjValidacao.Validar(f.Documento)).Equal(true)
                    .WithMessage("O documento fornecido é inválido");

            });
        }
    }
}
