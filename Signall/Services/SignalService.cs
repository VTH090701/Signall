using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Radzen;
using Signall.Data;
using System.Net.Http;
using Microsoft.JSInterop;
using System.Text;

namespace Signall.Services
{
    public class SignalService : ISignalService
    {
        private readonly HttpClient httpClient;
        private string Token = "FV0pJclr75laKx/PEkYYF4kZaGxwEfsxTh+W6IPBVJAvIcE1J0gE/BEEMt16hHzkJ1ouLds10mB+v+ou8w7q4Zp5GeHUFcJpResHiwCfmjLDS1TrMVaKl0NWgHac7VgiiAVmP0LdhFua7CPIDK6LJSkxI+IYs8VllLGUq78mPrvcReSAqG70q8zJJPYRpe9kwjsAfwUo6ijwa3of7IkIn1vr27021U5gNwamJIwHQyRz6WGmNCldw7WdlBWGvCcdOvtcoLHic/TQ2f/rr5sqxI8RrVaYAXUM/qILaxKwVUhstaoZFM4J39ldA/aEuyLhpn1Cknv300HFg8nPCDOHQg==";

        public SignalService(HttpClient http)
        {
            httpClient = http;
        }
        public async Task<ApiResult<Signal>> GetSignal()
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://14.241.182.251:59325/api/dashboard/medical/signals/W3siY29kZSI6ImVuY291bnRlciIsInZhbHVlIjoiMjQwMDA0MDIifV0="),
                    Method = HttpMethod.Get,
                };
                request.Headers.Add("token", Token);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                return await response.Content.ReadFromJsonAsync<ApiResult<Signal>>();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();

            }

        }
        public async Task<Response> CreateSignal(string codesignal, string unit, string Value)
        {
            try
            {
                var url = $"http://14.241.182.251:59325/api/observation/signal";

                if (codesignal == "SIG_10")
                {
                    var req = new
                    {
                        data = new
                        {
                            type = "new",
                            code = codesignal,
                            value_string = Value,
                            encounter = 24000402,
                            request = 0,
                            division = 29587
                        },
                        token = Token,
                        ip = "192:168:1:18",
                        code = "ad568891-dbc4-4241-a122-abb127901972"
                    };
                    var jsonContent = JsonConvert.SerializeObject(req);
                    var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                    var request = new HttpRequestMessage(HttpMethod.Put, url);
                    request.Content = content;

                    var response = await httpClient.SendAsync(request);
                    return await response.Content.ReadFromJsonAsync<Response>();

                }
                else
                {
                    var req = new
                    {
                        data = new
                        {
                            type = "new",
                            code = codesignal,
                            value = Value,
                            value_string = "",
                            unit = unit,
                            encounter = 24000402,
                            request = 0,
                            division = 29587
                        },
                        token = Token,
                        ip = "192:168:1:18",
                        code = "ad568891-dbc4-4241-a122-abb127901972"
                    };
                    var jsonContent = JsonConvert.SerializeObject(req);
                    var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                    var request = new HttpRequestMessage(HttpMethod.Put, url);
                    request.Content = content;

                    var response = await httpClient.SendAsync(request);
                    return await response.Content.ReadFromJsonAsync<Response>();

                };


            }
            catch (Exception ex)
            {
                throw new NotImplementedException();

            }
           
        
         
        }

        public async Task<Response> DeleteSignal(string code, string seq )
        {
            try
            {
                var url = $"http://14.241.182.251:59325/api/observation/signal";
                var req = new
                {
                    data = new
                    {

                        type = "cancel",
                        code = code,
                        seq = seq,
                        encounter = "24000402",
                        note = "234"
                    },
                    token = Token,
                    ip = "192:168:1:18",
                    code = "ad568891-dbc4-4241-a122-abb127901972"
                };
                var jsonContent = JsonConvert.SerializeObject(req);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Put, url);
                request.Content = content;

                var response = await httpClient.SendAsync(request);
                return await response.Content.ReadFromJsonAsync<Response>();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();

            }


        }
        public async Task<Response> UpdateSignal(string codeupdate, string sequpdate, string unitupdate, string Value)
        {
            try
            {
                var url = $"http://14.241.182.251:59325/api/observation/signal";
                var req = new
                {
                    data = new
                    {
                        type = "edit",
                        code = codeupdate,
                        seq = sequpdate,
                        value = Value,
                        value_string = "",
                        unit = unitupdate,
                        encounter = 24000402
                    },
                    token = Token,
                    ip = "192:168:1:18",
                    code = "ad568891-dbc4-4241-a122-abb127901972"
                };
                var jsonContent = JsonConvert.SerializeObject(req);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Put, url);
                request.Content = content;

                var response = await httpClient.SendAsync(request);
                return await response.Content.ReadFromJsonAsync<Response>();
            }catch (Exception ex) { 
                throw new NotImplementedException();
            }
         
                


        }
        public async Task<ApiResult<AllorListSignal>> GetAllSignal(string Id)
        {

            try
            {
                var para = new
                {
                    type = Id,
                    encounter = 24000402
                };
                var jsonContent = JsonConvert.SerializeObject(para);
                byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonContent);
                string base64EncodedString = Convert.ToBase64String(jsonBytes);



                var request = new HttpRequestMessage(HttpMethod.Get, $"http://14.241.182.251:59325/api/observation/signal/{base64EncodedString}");
                request.Headers.Add("token", Token);

                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var jsonString = await response.Content.ReadAsStringAsync();
                var apiResult = JsonConvert.DeserializeObject<ApiResult<AllorListSignal>>(jsonString);

                return apiResult;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();

            }



        }

        public async Task<ApiResult<AllorListSignal>> GetListSignal()
        {

            try
            {
                var para = new
                {
                    type = "all",
                    encounter = 24000402
                };
                var jsonContent = JsonConvert.SerializeObject(para);
                byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonContent);
                string base64EncodedString = Convert.ToBase64String(jsonBytes);


                var request = new HttpRequestMessage(HttpMethod.Get, $"http://14.241.182.251:59325/api/observation/signal/{base64EncodedString}");
                request.Headers.Add("token", Token);

                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var jsonString = await response.Content.ReadAsStringAsync();
                var apiResult = JsonConvert.DeserializeObject<ApiResult<AllorListSignal>>(jsonString);

                return apiResult;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();

            }
          
 
        }

     
    }
}
