﻿using System;
using System.IO;
using System.Net;
using System.Text;

namespace cs_restClient
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    class RESTClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }

        public RESTClient()
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.GET;
            // GETRequest.Headers.Add("x-api-key", "QYi7JGgICN2wKLP0K1cof8v6veepaSu97R31G0m7");
        }

        public string makeRequest()
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = httpMethod.ToString();
            request.Headers.Add("x-api-key", "QYi7JGgICN2wKLP0K1cof8v6veepaSu97R31G0m7");

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if(response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("error code: " + response.StatusCode.ToString());
                }
                // Process the response stream... (could be JSON, XML or HTML etc.)

                using (Stream responseStream = response.GetResponseStream())
                {
                    if(responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        } // End of StreamRead
                    }
                } // Enf of using Response Stream

            } // End of using Response

            return strResponseValue;
        }


    }
}
