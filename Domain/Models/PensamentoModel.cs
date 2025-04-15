using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PensamentoModel
    {
        public int Id { get; set; }
        public string Pensamento { get; set; }
        public string Autor { get; set; }
        public int Modelo { get; set; }
    }
}
