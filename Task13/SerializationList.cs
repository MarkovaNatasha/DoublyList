using System.IO;
using System.Xml.Serialization;

namespace Task13
{
    class SerializationList
    {
        public static void SaveListXML(string fileName, MyDoublyList<Student> student)
        {
            using (var sw = new StreamWriter(fileName))
            {
                var xmlSer = new XmlSerializer(student.GetType());
                xmlSer.Serialize(sw, student);
            }
        }

        public static MyDoublyList<Student> LoadListXML(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                var xmlDeser = new XmlSerializer(typeof(MyDoublyList<Student>));
                return (MyDoublyList<Student>)xmlDeser.Deserialize(sr);
            }
        }
    }
}
