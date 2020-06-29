using System.IO;
using System.Xml.Serialization;

namespace StopWatch.Data
{
    public class XmlUserSettings
    {
        private static XmlSerializer xmlSerializer;
        private string fileName; 

        public XmlUserSettings(string SaveToLocation, object SaveObjectType)
        {
            fileName = SaveToLocation;
            xmlSerializer = new XmlSerializer(SaveObjectType.GetType());
        }

        public void SaveToFile(object SaveObject)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xmlSerializer.Serialize(sw, SaveObject);
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
