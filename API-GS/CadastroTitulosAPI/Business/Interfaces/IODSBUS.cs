using DAL.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Business.Interfaces
{
    public interface IODSBUS
    {
        public List<Indicador> BuscarObjetivos(IRepositoryBase repository);
        public List<ObjetivoIndicador> BuscarObjetivosIndicadores(IRepositoryBase repository);
        public IEnumerable<Indicador> BuscarIndicador(IRepositoryBase repository, string codigo);
        public List<Indicador> BuscarIndicadorPorRegiao(IRepositoryBase repository, Indicador ind);


    }
}
