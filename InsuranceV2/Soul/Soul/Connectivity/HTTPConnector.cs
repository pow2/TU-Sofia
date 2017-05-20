using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soul.Structures;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Soul.Connectivity
{
    public class HTTPConnector
    {
        //-----------------------------------------------------------------------------------------------
        private static string ERROR = "Няма достъп до сървъра.";
        private static string WAIT = "Моля изчакайте.";
        //-----------------------------------------------------------------------------------------------
        private ConnectionData cdata;
        //-----------------------------------------------------------------------------------------------
        public HTTPConnector(ConnectionData cdata)
        {
            this.cdata = cdata;
        }
        //-----------------------------------------------------------------------------------------------
        public async void SendToAsync(string message, string endpoint, ISender sender)
        {
            Uri uri = new Uri("http://" + cdata.ToString() + endpoint);
            HttpClient client = new HttpClient();
            string respBody = String.Empty;
            client.Timeout = new TimeSpan(0, 60, 60);
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            try
            {
                if (sender != null)
                {
                    sender.RenderResponseAsync(WAIT);
                }

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpResponse = await client.PostAsync(uri, new StringContent(message, Encoding.UTF8, "application/json"));
                httpResponse.EnsureSuccessStatusCode();
                respBody = await httpResponse.Content.ReadAsStringAsync(); ;
            }
            catch (Exception e)
            {
                respBody = ERROR;
            }
            if (sender != null)
            {
                sender.RenderResponseAsync(respBody);
            }
            
        }
        //-----------------------------------------------------------------------------------------------
    }
}
