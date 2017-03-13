using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Serialization;


namespace Evol.Util.Serialization
{
    public static class XmlUtil
    {

        public static T DeSerialize<T>(string xml)
        {
            T obj;
            using (StringReader reader = new StringReader(xml))
            {
                var serialize = new XmlSerializer(typeof(T));
                obj = (T)serialize.Deserialize(reader);
            }
            return obj;
        }

        public static string Serialize(object obj)
        {
            string str;
            using(var ms1 = new MemoryStream())
            {
                using (var writer = XmlWriter.Create(ms1, new XmlWriterSettings { Encoding = Encoding.UTF8 }))
                {
                    var ser = new XmlSerializer(obj.GetType());
                    ser.Serialize(writer, obj);
                    str = Encoding.UTF8.GetString(ms1.ToArray());
                }
            }
            return str;
        }

        public static string SerializeClean(object obj)
        {
            string result = null;
            var setting = new XmlWriterSettings();
            setting.Encoding = Encoding.UTF8;
            setting.CloseOutput = true;
            setting.OmitXmlDeclaration = true;
            var ms = new MemoryStream();
            using (var writer = XmlWriter.Create(ms, setting))
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add(String.Empty, String.Empty);
                var ser = new XmlSerializer(obj.GetType());
                ser.Serialize(writer, obj, ns);
                result = Encoding.UTF8.GetString(ms.ToArray());
            };

            return result;
        }



    }
}
