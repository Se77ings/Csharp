using FinancasKiss.Business.Models;
using FinancasKiss.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasKiss.Business.Services
{
    public class DemonstrativoService : IDemonstrativoService
    {
        private List<Demonstrativo> _demonstrativos = new List<Demonstrativo>();

       
        public void CriarDemonstrativo(int mes)
        {
            var demonstrativo = new Demonstrativo(mes);
            _demonstrativos.Add(demonstrativo);
        }

        public List<Demonstrativo> ObterDemonstrativos()
        {
            return _demonstrativos;
        }
    }
}
