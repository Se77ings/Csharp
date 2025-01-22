using System.ComponentModel.DataAnnotations;

namespace Wishlist.Client.Ideia2
{
    public class Mes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NomeMes { get; set; }
        [Required]
        public int NumeroMes { get; set; }
        [Required]
        public List<GastoMes> GastosMes { get; set; }
        [Required]
        public SalarioMes SalarioMes { get; set; }

        public Mes(int id, string nomeMes, int numeroMes)
        {
            Id = id;
            NomeMes = nomeMes;
            NumeroMes = numeroMes;
            GastosMes = new List<GastoMes>(); // Inicialização padrão
            SalarioMes = null; // Pode ser configurado posteriormente
        }
       
    }
}
