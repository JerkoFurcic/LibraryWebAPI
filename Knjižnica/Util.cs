using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Knjižnica
{
    public static class Util
    {
        private const String baseURL = "http://localhost:59403/api/";

        public static string KnjiznicaID { get => KnjiznicaID; set => KnjiznicaID = value; }

        public static void POST(string url, string jsonContent)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseURL + url);
            request.Method = "POST";

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(jsonContent);

            request.ContentLength = byteArray.Length;
            request.ContentType = @"application/json";

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            long length = 0;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    length = response.ContentLength;

                }
            }
            catch
            {
                throw;
            }
        }

        public static void PUT(string url, string jsonContent)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseURL + url);
            request.Method = "PUT";

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(jsonContent);

            request.ContentLength = byteArray.Length;
            request.ContentType = @"application/json";

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            long length = 0;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    length = response.ContentLength;

                }
            }
            catch
            {
                throw;
            }
        }

        public static void Delete(String urlClass, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync(urlClass + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return;
                }
            }

            return;
        }
    }
}
