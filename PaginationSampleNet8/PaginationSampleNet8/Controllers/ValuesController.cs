using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaginationSampleNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {


        // POST api/<ValuesController>
        [HttpPost]
        public string Post([FromBody] Root value)
        {
            return value.fullData.id.ToString() + " " + value.fullData.idCorrelativo.ToString();
        }


    }

    public class FullData
    {
        public object? esNuevo { get; set; }
        public object? fechaHora { get; set; }
        public object? temporada { get; set; }
        public object? id { get; set; }
        public object? tipo { get; set; }
        public object? estado { get; set; }
        public object? justificacionEstado { get; set; }
        public object? areaAfectada { get; set; }
        public List<double>? centroide { get; set; }
        public object? fuenteDeteccion { get; set; }
        public object? fuenteAviso { get; set; }
        public object? indicePeligro { get; set; }
        public object? orientacion { get; set; }
        public object? fundoId { get; set; }
        public object? createdAt { get; set; }
        public object? centrodecostos { get; set; }
        public object? georef { get; set; }
        public object? observacion { get; set; }
        public object? idCorrelativo { get; set; }
        public object? nombreIncidente { get; set; }
        public object? estadoIncidente { get; set; }
        public object? actividad { get; set; }
        public object? estadoR22 { get; set; }
        public object? centroCosto { get; set; }
        public object? unidadAnalisis { get; set; }
        public object? isDelete { get; set; }
        public object? fecha { get; set; }
    }

    public class Root
    {
        public string? name { get; set; }
        public string? ocurredAt { get; set; }
        public string? eventId { get; set; }
        public string? aggregateId { get; set; }
        public string? tipoIncidente { get; set; }
        public FullData? fullData { get; set; }
    }
}
