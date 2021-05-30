using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConcentradorBackend.Dtos.Request;
using ConcentradorBackend.Dtos.Response;
using ConcentradorBackend.Interfaces;
using ConcentradorBackend.Models;
using ConcentradorBackend.Util;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConcentradorBackend.DataAccess
{
    public class ConsultaProductoDataAccessLayer: IConsultaProductoService
    {
        private readonly ConcentradorDBContext _dbContext;
        readonly IConsultaProductoService _consultaProductoService;

        public ConsultaProductoDataAccessLayer(ConcentradorDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public List<ConsultaEntidadProducto> consulta(ConsultaProductoFinancieroRequest request, int pagina)
        {
            try
            {
                
               
                var consulta = from cep in _dbContext.ConsultaEntidadProducto
                                                                                select cep;
                
                if (!String.IsNullOrEmpty(request.CodigoProductoFinanciero.ToString()))
                {
                    consulta = consulta.Where(s => s.TipoProductoId == request.CodigoProductoFinanciero);
                }
                
                if (!String.IsNullOrEmpty(request.TipoMonedaId.ToString()))
                {
                    consulta = consulta.Where(s => s.MonedaId == request.TipoMonedaId);
                }
                
                if (!String.IsNullOrEmpty(request.MontoMaximoAceptable.ToString()))
                {
                    consulta = consulta.Where(s => s.MontoMaximoPrestamo >= request.MontoMaximoAceptable);
                }
                if (!String.IsNullOrEmpty(request.PlazoMaximoMes.ToString()))
                {
                    consulta = consulta.Where(s => s.PlazoMaximoMes >= request.PlazoMaximoMes);
                }
                if (!String.IsNullOrEmpty(request.IngresoPermitido.ToString()))
                {
                    consulta = consulta.Where(s => s.IngresoPermitido >= request.IngresoPermitido);
                }
                if (!String.IsNullOrEmpty(request.DepartamentoId.ToString()))
                {
                    consulta = consulta.Where(s => s.DepartamentoId == request.DepartamentoId);
                }
                if (!String.IsNullOrEmpty(request.TipoInstitucionId.ToString()))
                {
                    consulta = consulta.Where(s => s.TipoInstitucionId == request.TipoInstitucionId);
                }
                if (!String.IsNullOrEmpty(request.MontoMaximoDeposito.ToString()))
                {
                    consulta = consulta.Where(s => s.MontoMaximoDeposito >= request.MontoMaximoDeposito);
                }
                if (!String.IsNullOrEmpty(request.PlazoMaximoDia.ToString()))
                {
                    consulta = consulta.Where(s => s.PlazoMaximoDia >= request.PlazoMaximoDia);
                }

                return (List<ConsultaEntidadProducto>) consulta.AsNoTracking()
                    .OrderBy(x => x.ConsultaEntidadProductoId)
                    .GetPaged(pagina, 20).Results;
            }
            catch
            {
                throw;
            }
        }

        public ConsultaEntidadProducto consultaId(int id)
        {

          try
           {
                var entidadesproducto = from entidadproducto in _dbContext.ConsultaEntidadProducto

                            where entidadproducto.ConsultaEntidadProductoId == id

                            select entidadproducto;

                var entidadProducto = entidadesproducto.FirstOrDefault();
                Console.WriteLine("CONSULTA: ");
                ConsultaEntidadProducto entidad = entidadProducto;

                return entidad;
           }
           catch
           {
               throw;
           }

        }

        public Prospecto guardarPrestamo(Prospecto request)
        {

            try
            {
                Prospecto prospecto = new Prospecto();
                prospecto.Apellidos = request.Apellidos;
                prospecto.DepartamentoId = request.DepartamentoId;
                prospecto.Email = request.Email;
                prospecto.Nombres = request.Nombres;
                prospecto.NumeroCelular = request.NumeroCelular;
                prospecto.NumeroDocumento = request.NumeroDocumento;
                prospecto.TipoDocumentoId = request.TipoDocumentoId;
                prospecto.FechaRegistro = DateTime.Now;
                _dbContext.Prospecto.Add(prospecto);
                _dbContext.SaveChanges();
                return request;
            }
            catch
            {
                throw;
            }

        }
    }
}