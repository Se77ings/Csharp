using FluentValidation;
using NerdStore.Core.Messages;
using static NerdStore.Vendas.Application.Commands.AtualizarItemPedidoCommand;

namespace NerdStore.Vendas.Application.Commands
{
    public class AplicarVoucherItemPedidoCommand : Command
    {
        public Guid ClienteId { get; private set; }
        public string CodigoVoucher { get; private set; }

        public AplicarVoucherItemPedidoCommand(string codigoVoucher, Guid clienteId)
        {
            CodigoVoucher = codigoVoucher;
            ClienteId = clienteId;
        }

        public override bool EhValido()
        {
            ValidationResult = new AplicarVoucherItemPedidoValidator().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AplicarVoucherItemPedidoValidator : AbstractValidator<AplicarVoucherItemPedidoCommand>
        {
            public AplicarVoucherItemPedidoValidator()
            {
                RuleFor(c => c.ClienteId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do cliente inválido");

                RuleFor(c => c.CodigoVoucher)
                    .NotEmpty()
                    .WithMessage("O código do voucher não foi informado");
            }
        }
    }
}
