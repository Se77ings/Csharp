using FluentValidation;
using NerdStore.Core.Messages;
using NerdStore.Vendas.Application.Commands;

namespace NerdStore.Vendas.Application.Commands
{
    public class IniciarPedidoCommand : Command
    {
        public Guid PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }
        public decimal ValorTotal { get; private set; }
        public string NomeCartao { get; private set; }
        public string NumeroCartao { get; private set; }
        public string ExpiracaoCartao { get; private set; }
        public string Cvv { get; private set; }
        public IniciarPedidoCommand(Guid pedidoId, Guid clienteId, decimal valorTotal, string nomeCartao, string numeroCartao, string expiracaoCartao, string cvv)
        {
            PedidoId = pedidoId;
            ClienteId = clienteId;
            ValorTotal = valorTotal;
            NomeCartao = nomeCartao;
            NumeroCartao = numeroCartao;
            ExpiracaoCartao = expiracaoCartao;
            Cvv = cvv;
        }
    }
}

public class IniciarPedidoValidation : AbstractValidator<IniciarPedidoCommand>
{
    public IniciarPedidoValidation()
    {
        RuleFor(c => c.PedidoId)
            .NotEqual(Guid.Empty)
            .WithMessage("O id do pedido não foi informado");

        RuleFor(c => c.ClienteId)
            .NotEqual(Guid.Empty)
            .WithMessage("O id do cliente não foi informado");

        RuleFor(c => c.ValorTotal)
            .GreaterThan(0)
            .WithMessage("O valor total do pedido deve ser maior que zero");

        RuleFor(c => c.NomeCartao)
            .NotEmpty()
            .WithMessage("O nome do cartão não foi informado")
            .Length(2, 100)
            .WithMessage("O nome do cartão deve ter entre 2 e 100 caracteres");

        RuleFor(c => c.NumeroCartao)
            .NotEmpty()
            .WithMessage("O número do cartão não foi informado")
            .CreditCard()
            .WithMessage("O número do cartão é inválido");

        RuleFor(c => c.Cvv)
            .Length(3, 4)
            .WithMessage("O CVV do cartão deve ter entre 3 e 4 dígitos");
    }
}
