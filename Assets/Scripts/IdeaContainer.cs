using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;


[XmlRoot("IdeaCollection")]
public class IdeaContainer
{    
    [XmlArray("Ideas")]
    [XmlArrayItem("Idea")]
    public List<Idea> ideas = new List<Idea>();


    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(IdeaContainer));

        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static IdeaContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(IdeaContainer));

        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as IdeaContainer;
        }
    }
}
