using System.Collections.Generic;
using System.Threading.Tasks;
using ConcentradorBackend.Dtos.Request;
using ConcentradorBackend.Dtos.Response;
using ConcentradorBackend.Models;

namespace ConcentradorBackend.Interfaces
{
    public interface IConsultaProductoService
    {
        List<ConsultaEntidadProducto> consulta(ConsultaProductoFinancieroRequest request, int pagina);

        ConsultaEntidadProducto consultaId(int id);

        Prospecto guardarPrestamo(Prospecto request);
    }
}