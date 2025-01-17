using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Wishlist.Data;

namespace Wishlist.Components.Lista
{
    //Gerar o Scaffold dessa classe
    public class Lista
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome não pode ser vazio")]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Prioridade não pode ser vazia")]
        public int Prioridade { get; set; }
        public string Link { get; set; }
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public decimal Valor { get; set; }
        public void AumentarPrioridade()
        {

            this.Prioridade += 1;
        }

        public void DiminuirPrioridade()
        {
            if (this.Prioridade > 0)
            {

                this.Prioridade -= 1;
            }
        }
    }
}