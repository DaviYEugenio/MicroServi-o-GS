using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ODS
    {
        public int idOds { get; set; }        
        public int codigo { get; set; }  
        public virtual Objetivo Objetivo { get; set; }
        public int idObjetivo { get; set; }
    }
}
