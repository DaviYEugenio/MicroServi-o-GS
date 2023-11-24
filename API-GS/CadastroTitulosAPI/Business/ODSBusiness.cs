using Business.Interfaces;
using DAL.Base;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ODSBusiness : IODSBUS
    {
        private readonly IODSDAL _obsDao;

        public ODSBusiness(IODSDAL obsDao)
        {
            _obsDao = obsDao;
        }

        public List<Indicador> BuscarObjetivos(IRepositoryBase repository)
        {
            return _obsDao.BuscarObjetivos(repository);
        }

        public IEnumerable<Indicador> BuscarIndicador(IRepositoryBase repository, string codigo)
        {
            return _obsDao.BuscarIndicador(repository, codigo);
        }

        public List<Indicador> BuscarIndicadorPorRegiao(IRepositoryBase repository, Indicador indicador)
        {
            return _obsDao.BuscarIndicadorPorRegiao(repository, indicador);
        }


    }
}
