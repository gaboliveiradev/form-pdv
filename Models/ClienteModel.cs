using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211074.Models
{
    public class ClienteModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int id_cidade { get; set; }
        public DateTime data_nasc { get; set; }
        public double renda { get; set; }
        public string cpf { get; set; }
        public string foto { get; set; }
        public bool venda { get; set; }
    }
}
