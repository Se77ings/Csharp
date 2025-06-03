using FluentValidation;
using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Application.Commands
{
    public partial class AdicionarItemPedidoCommand : Command

    {

        // aqui passa tudo que for necessário para adicionar um item ao pedido
        public Guid ClienteId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public AdicionarItemPedidoCommand(Guid clienteId, Guid produtoId, string nome, int qtd, decimal valorUnit)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
            Nome = nome;
            Quantidade = qtd;
            ValorUnitario = valorUnit;

        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        // como é daqui que parte a intenção de alteração, é melhor validar aqui mesmo, do que na classe em sí.
        public class AdicionarItemPedidoValidation : AbstractValidator<AdicionarItemPedidoCommand>
        {
            public AdicionarItemPedidoValidation()
            {
                RuleFor(c => c.ClienteId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do cliente inválido");

                RuleFor(c => c.ProdutoId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do produto inválido");

                RuleFor(c => c.Nome)
                    .NotEmpty()
                    .WithMessage("O nome do produto não foi informado");

                RuleFor(c => c.Quantidade)
                    .GreaterThan(0)
                    .WithMessage("A quantidade miníma de um item é 1");

                RuleFor(c => c.Quantidade)
                    .LessThan(15)
                    .WithMessage("A quantidade máxima de um item é 15");

                RuleFor(c => c.ValorUnitario)
                    .GreaterThan(0)
                    .WithMessage("O valor do item precisa ser maior que 0");

            }
        }

    }
}
