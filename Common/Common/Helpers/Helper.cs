using System;
using System.Web;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;
using System.Xml.Serialization;
using System.IO;

namespace Zch.Common.Helpers
{
    public class Helper
    {
        public static string Strip(string text)
        {
            return Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
        }
        private static void SerializeToXmlFile<T>(T responseType)
        {
            string filePath = @"c:\dev\response.xml";
            SerializeToXmlFile(responseType, filePath);
        }
        public static void SerializeToXmlFile<T>(T responseType, string filePath)
        {
            XmlSerializer writer = new XmlSerializer(typeof(T));
            using (StreamWriter file = new StreamWriter(filePath))
            {
                writer.Serialize(file, responseType);
            }
        }
        public static bool IsNumber(string number)
        {
            bool isNumber = default(bool);
            int num;

            isNumber = Int32.TryParse(number, out num);

            return isNumber;
        }
        public static string GetUser_IP()
        {
            string VisitorsIPAddr = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
            }
            return VisitorsIPAddr;
        }
        public static string GetUserIP()
        {
            string ipList = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        public static List<KeyValuePair<string, int>> GetIpAdress()
        {
            try
            {
                List<KeyValuePair<string, int>> ipList = new List<KeyValuePair<string, int>>();
                //ipv4
                string visitorIp = GetUser_IP();
                int intAddress = BitConverter.ToInt32(IPAddress.Parse(visitorIp).GetAddressBytes(), 0);

                ipList.Add(new KeyValuePair<string, int>(visitorIp, intAddress));
                return ipList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
