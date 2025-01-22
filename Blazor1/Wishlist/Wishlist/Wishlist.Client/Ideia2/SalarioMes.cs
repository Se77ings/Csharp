using System.ComponentModel.DataAnnotations;

namespace Wishlist.Client.Ideia2
{
    public class SalarioMes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateOnly Data { get; set; }
        [Required]
        public decimal Valor { get; set; }

        public SalarioMes(int id, DateOnly data, decimal valor)
        {
            Id = id;
            Data = data;
            Valor = valor;
            
        }
    }
}
