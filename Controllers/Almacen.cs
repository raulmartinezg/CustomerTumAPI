using ClientTum.Entities;
using ClientTum.Interface;
using ClientTum.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientTum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Almacen : ControllerBase
    {
        private readonly IRepository _repository;
        public Almacen(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetFolios()
        {
            var data = await ServiceTUM.FolioViajeGeneralGet();
            await _repository.CleanFolios();
            var response = await _repository.UpdateFolios(data);
            return Ok(response);
        }

        [HttpGet("Concesionario")]
        public async Task<IActionResult> GetConcesionario([FromQuery] int clave)
        {
            var data = await ServiceTUM.ConcesionarioGet(clave);
            var response = await _repository.UpdateConcesionario(data);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostJson(List<Shipment> obj)
        {
            var json = new Json()
            {
                claveFolioViaje = Convert.ToInt32(obj[0].shipmentId),
                fechaCaptura = DateTime.Now,
                json = JsonConvert.SerializeObject(obj[0])

            };
            var data = await ServiceTUM.SendJson(json);
            return Ok(data);
        }
    }
}
