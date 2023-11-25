using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Indicador
    {
        public int idIndicador { get; set; }
        public int ano { get; set; }
        public string regiao { get; set; }
        public string codigo { get; set; }
        public decimal consumo { get; set; }
        public string descricao { get; set; }
        public virtual ODS ods { get; set; }
        public int idOds { get; set; }
    }
}
