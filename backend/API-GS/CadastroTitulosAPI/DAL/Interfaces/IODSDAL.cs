using System;
using System.Collections.Generic;
using System.Text;
using DAL.Base;
using Model;

namespace DAL.Interfaces
{
    public interface IODSDAL
    {
        public List<Indicador> BuscarObjetivos(IRepositoryBase repository);
        public List<ObjetivoIndicador> BuscarObjetivosIndicadores(IRepositoryBase repository);
        public IEnumerable<Indicador> BuscarIndicador(IRepositoryBase repository, string codigo);
        public List<Indicador> BuscarIndicadorPorRegiao(IRepositoryBase repository, Indicador indicador);

    }
}
