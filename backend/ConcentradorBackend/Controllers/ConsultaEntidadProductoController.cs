using System.Collections.Generic;
using System.Threading.Tasks;
using ConcentradorBackend.Dtos.Request;
using ConcentradorBackend.Dtos.Response;
using ConcentradorBackend.Interfaces;
using ConcentradorBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConcentradorBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ConsultaController : Controller
    {

        private readonly IConsultaProductoService _consultaProductoService;

        public ConsultaController(IConsultaProductoService consultaProductoService)
        {
            _consultaProductoService = consultaProductoService;
        }
        
        [HttpPost]
        [Route("producto-financiero/pagina/{page}")]
        public List<ConsultaEntidadProducto> Post([FromBody] ConsultaProductoFinancieroRequest request, int page)
        {
            return _consultaProductoService.consulta(request, page);
        }

        [HttpGet]
        [Route("{id}")]
        public ConsultaEntidadProducto consultaId(int id)
        {
            ConsultaEntidadProducto result = _consultaProductoService.consultaId(id);
            return result;
        }

        [HttpPost]
        [Route("prospecto")]
        public Prospecto guardarPrestamo([FromBody] Prospecto request)
        {
            Prospecto result = _consultaProductoService.guardarPrestamo(request);
            return result;
        }
    }
}