using System.IO;
using System.Xml.Serialization;

namespace StopWatch.Data.Services
{
    public class XmlUserSettings
    {
        private static XmlSerializer xmlSerializer;
        private readonly string fileName;

        public XmlUserSettings(string saveToLocation, object saveObjectType)
        {
            fileName = saveToLocation;
            xmlSerializer = new XmlSerializer(saveObjectType.GetType());
        }

        public void SaveToFile(object saveObject)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xmlSerializer.Serialize(sw, saveObject);
            }
        }

        public object ReadFromFile()
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                return xmlSerializer.Deserialize(sr) as object;
            }
        }
    }
}
