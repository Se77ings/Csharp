using System.ComponentModel.DataAnnotations;

namespace Wishlist.Client.Ideia2
{
    public class GastoMes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public TipoGasto TipoGasto { get; set; }


        public GastoMes(int id, string descricao, decimal valor, TipoGasto tipo)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
            TipoGasto = tipo;
            
        }
    }
}
