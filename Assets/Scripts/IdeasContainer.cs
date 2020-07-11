using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;


[XmlRoot("IdeaCollection")]
public class IdeasContainer
{    
    [XmlArray("Ideas")]
    [XmlArrayItem("Idea")]
    public List<Idea> ideas = new List<Idea>();


    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(IdeasContainer));

        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static IdeasContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(IdeasContainer));

        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as IdeasContainer;
        }
    }
}
