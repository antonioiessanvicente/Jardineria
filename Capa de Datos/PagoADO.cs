using System;
using System.Collections.Generic;
using Entidades;

// Para contactar con la WEB API
using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Threading.Tasks;


namespace Capa_Datos
{
        public class PagoADO : ADO
        {
            // Leo todos los pagos dela BD
            public List<Pago> LeerPagos()
            {
                List<Pago> listaUsuarios = new List<Pago>();
                string aux;

                try
                {
                    HttpResponseMessage response = client.GetAsync("api/pagos").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        aux = response.Content.ReadAsStringAsync().Result;

                        listaUsuarios = JsonConvert.DeserializeObject<List<Pago>>(aux);
                    }
                }
                catch (Exception e)
                {
                    throw new ExternalException("Error:" + e);
                }

                return listaUsuarios;
            }
            public List<Pago> LeerPago(int id)
            {
                List<Pago> listaUsuarios = new List<Pago>();
                string aux;

                try
                {
                    HttpResponseMessage response = client.GetAsync("api/pagos/" + id).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        aux = response.Content.ReadAsStringAsync().Result;

                        listaUsuarios = JsonConvert.DeserializeObject<List<Pago>>(aux);
                    }
                }
                catch (Exception e)
                {
                    throw new ExternalException("Error:" + e);
                }

                return listaUsuarios;
            }
            
        // Creo un nuevo pago en la BD
            public async Task<bool> InsertarPagoAsync(string nom, string pas)
            {
                try
                {
                
                Pago pay = new Pago();// CAMBIAR A LOS PARAMETROS QUE CORRESPONDAN

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "api/pagos");
                string json = JsonConvert.SerializeObject(pay);
                request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpClient http = new HttpClient();
                HttpResponseMessage response = await http.SendAsync(request);

                if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error " + e);
                }

                return true;
            }
            public async Task<bool> ActualizarPagoAsync(Pago pay)
            {
                try
                {
                
                //HttpResponseMessage response = client.PutAsJsonAsync("api/pagos/" + pay.Id_Transaccion, Pago).Result;

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, "api/pagos");
                string json = JsonConvert.SerializeObject(pay);
                request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpClient http = new HttpClient();
                HttpResponseMessage response = await http.SendAsync(request);

                if (response.IsSuccessStatusCode)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new ExternalException("Error:" + e);
                }
            }

            public bool BorrarPago(int id)
            {
                try
                {

                    HttpResponseMessage response = client.DeleteAsync("api/pagos/" + id).Result;

                    if (response.IsSuccessStatusCode)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new ExternalException("Error:" + e);
                }
            }

        }
    }


