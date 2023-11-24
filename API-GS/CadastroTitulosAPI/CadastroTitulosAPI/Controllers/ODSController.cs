using Business.Interfaces;
using DAL.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace CadastroTitulosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ODSController : ControllerBase
    {
        private readonly IODSBUS _seriesMateriaColecaoTitulos;
        private IRepositoryBase _repositoryBase;

        public ODSController(IODSBUS seriesMateriaColecaoTitulos, IRepositoryBase repositoryBase)
        {
            _repositoryBase = repositoryBase;
            _seriesMateriaColecaoTitulos = seriesMateriaColecaoTitulos;
        }

        [HttpGet("Objetivos")]
        public ActionResult Objetivos()
        {
            return Ok(_seriesMateriaColecaoTitulos.BuscarObjetivos(_repositoryBase));
        }

        [HttpPost("Indicador")]
        public ActionResult Indicador([FromBody] Indicador codigo)
        {
            return Ok(_seriesMateriaColecaoTitulos.BuscarIndicador(_repositoryBase, codigo.codigo));
        }

        [HttpPost("BuscarPorRegiao")]
        public ActionResult GetByRegiao([FromBody] Indicador indicador)
        {
            return Ok(_seriesMateriaColecaoTitulos.BuscarIndicadorPorRegiao(_repositoryBase, indicador));
        }


    }
}
