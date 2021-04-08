using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace rupture
{
    internal static class Http
    {
        public static string Get(string page)
        {
            try
            {
                HttpWebRequest httpRequest = WebRequest.Create(page) as HttpWebRequest;
                httpRequest.Headers.Set("Operating-system", OS.OperatingSystem);
                HttpWebResponse httpResponse = httpRequest.GetResponse() as HttpWebResponse;
                Stream httpStream = httpResponse.GetResponseStream();
                StreamReader reader = new StreamReader(httpStream, new UTF8Encoding(false, false));
                return reader.ReadToEnd();

            } catch (Exception e )
            {
                Logger.Log(e.StackTrace);
            } finally
            {
                Logger.Log("Get request to {0}", page);
            }
            return string.Empty;
        }
    }
}
