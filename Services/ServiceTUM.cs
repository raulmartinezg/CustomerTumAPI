using ClientTum.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientTum.Services
{
    public class ServiceTUM
    {
        const string WebApiURL = "https://portal.tum.com.mx/sa20";
        private static HttpClient Client = new HttpClient()
        {
            BaseAddress = new Uri(WebApiURL)
        };

        public static async Task<List<FolioViajeGeneral>> FolioViajeGeneralGet()
        {
            var data = new List<FolioViajeGeneral>();
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var url = $"{WebApiURL}/api/Link/Folios";
            var response = await Client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    var table = JsonConvert.DeserializeObject<List<FVDTO>>(json);
                    foreach (FVDTO e in table)
                    {
                        var folios = new FolioViajeGeneral()
                        {
                            ClaveFolioViaje = Convert.ToString(e.ClaveFolioViaje),
                            FolioViaje = e.FolioViaje,
                            Operador = e.Operador,
                            Placa = e.Placa,
                            Ruta = e.Ruta,
                            SalidaProgramada = e.SalidaProgramada,
                            Unidad = e.Unidad
                        };
                        data.Add(folios);
                    }
                }
            }
            return data;
        }

        public static async Task<List<ConcesionarioRutum>> ConcesionarioGet(int clave)
        {
            var data = new List<ConcesionarioRutum>();
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("clave", Convert.ToString(clave));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var url = $"{WebApiURL}/api/Link/Concesionario";
            var response = await Client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    var list = JsonConvert.DeserializeObject<List<ConcesionarioRuta>>(json);
                    foreach(ConcesionarioRuta e in list)
                    {
                        var conc = new ConcesionarioRutum()
                        {
                            Id = 0,
                            ClaveFolioViaje = e.c,
                            FolioViaje = e.f,
                            NumeroConcCte = e.n,
                            RazonSocial = e.r
                        };

                        data.Add(conc);
                    }
                    
                }
            }
            return data;
        }

        public static async Task<bool> SendJson(Json obj)
        {
            var data = new bool();
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var url = $"{WebApiURL}/api/Link/Json";
            var content = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(content,Encoding.UTF8,"application/json");
            var response = await Client.PostAsync(url,stringContent);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    data = JsonConvert.DeserializeObject<bool>(json);
                    
                }
            }
            return data;
        }
    }
}
