using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using CoreScheduler.Server.Utilities;

namespace CoreScheduler.Client.Desktop.Serializer
{
    public static class SerializerUtilities
    {

        #region Read

        public static string GetSafeValue(this XElement element)
        {
            return element == null ? "" : element.Value;
        }

        public static string GetSafeValue(this XAttribute attribute)
        {
            return attribute == null ? "" : attribute.Value;
        }

        public static Guid GetSafeValueGuid(this XElement element)
        {
            Guid id;
            if (element != null && Guid.TryParse(element.Value, out id))
                return id;
            return Guid.Empty;
        }

        public static Guid GetSafeValueGuid(this XAttribute attribute)
        {
            Guid id;
            if (attribute != null && Guid.TryParse(attribute.Value, out id))
                return id;
            return Guid.Empty;
        }

        public static DateTime GetSafeValueDateTime(this XElement element)
        {
            DateTime dt;
            if (element != null && DateTime.TryParse(element.Value, out dt))
                return dt;
            return DateTime.MinValue;
        }


        public static string GetSafeValueDecrypt(this XElement element, string secret, bool doDecrypt)
        {
            if (element == null)
                return "";

            if (doDecrypt)
                return StringEncryption.SimpleDecryptWithPassword(element.Value, secret);
            return element.Value;
        }

        public static bool IsEncrypted(this XElement element)
        {
            return (element.Attribute("encrypted").GetSafeValue() ?? "false").ToUpper() == "TRUE";
        }

        public static string Encrypt(this string s, string secret, bool doEncrypt)
        {
            if (doEncrypt)
                return StringEncryption.SimpleEncryptWithPassword(s, secret);
            return s;
        }

        private static readonly Regex NonBase64Chars = new Regex(@"[^A-Za-z0-9=+/]");

        public static string ReadDataBlockBase64String(this XElement element)
        {
            var data = element.GetSafeValue();

            if (data == null)
                return "";

            return NonBase64Chars.Replace(data, "");
        }

        public static byte[] ReadDataBlock(this XElement element)
        {
            var raw = element.ReadDataBlockBase64String();
            return Convert.FromBase64String(raw);
        }

        public static string ReadDataBlockUtf8String(this XElement element)
        {
            return Encoding.UTF8.GetString(element.ReadDataBlock());
        }

#endregion

        #region Write

        public static XElement WithAttribute(this XElement element, string attr, string value)
        {
            element.SetAttributeValue(attr, value);
            return element;
        }
        

        #endregion

    }
}
