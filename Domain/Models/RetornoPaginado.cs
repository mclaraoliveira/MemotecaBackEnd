using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RetornoPaginado<T>
    {
        public List<T> Itens { get; set; }
        public int TotalRegistros { get; set; }
        public int Pagina { get; set; }
        public int QtdPagina { get; set; }

        public RetornoPaginado(List<T> itens, int totalRegistros, int pagina, int qtdPagina)
        {
            Itens = itens;
            TotalRegistros = totalRegistros;
            Pagina = pagina;
            QtdPagina = qtdPagina;
        }
    }
}
