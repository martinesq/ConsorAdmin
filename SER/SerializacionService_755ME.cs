namespace SER
{
    public class SerializacionService_755ME
    {
        public void Serializar_755ME<T>(T objeto, string ruta)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (var writer = new System.IO.StreamWriter(ruta))
            {
                serializer.Serialize(writer, objeto);
            }
        }

        public T Deserializar_755ME<T>(string ruta)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (var reader = new System.IO.StreamReader(ruta))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
