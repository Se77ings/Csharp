using FluentValidation;
using FluentValidation.Results;
using NerdStore.Core.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace NerdStore.Vendas.Domain
{
    public class Voucher : Entity
    {
        public string Codigo { get; private set; }
        public decimal? PercentualDesconto { get; private set; }
        public decimal? ValorDesconto { get; private set; }
        public int Quantidade { get; private set; }
        public TipoDescontoVoucher TipoDescontoVoucher { get; private set; }
        public DateTime DataValidade { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataUtilizacao { get; private set; }
        public bool Ativo { get; private set; }
        public bool Utilizado { get; private set; }

        //Ef Rel.
        public ICollection<Pedido> Pedidos { get; set; } // 1: n pedidos

        public FluentValidation.Results.ValidationResult ValidarSeAplicavel()
        {
            return new VoucherAplicavelValidation().Validate(this);
        }

    }

    public class VoucherAplicavelValidation : AbstractValidator<Voucher>
    {
        public VoucherAplicavelValidation()
        {
            RuleFor(x => x.DataValidade)
                .NotEmpty()
                .WithMessage("Este voucher está expirado.");

            RuleFor(x => x.Ativo)
                .Equal(true)
                .WithMessage("Este voucher não está ativo.");

            RuleFor(x => x.Utilizado)
                .Equal(false)
                .WithMessage("Este voucher já foi utilizado.");

            RuleFor(x => x.Quantidade)
                .GreaterThan(0)
                .WithMessage("Este voucher não possui mais unidades disponíveis.");


        }

    }
}
