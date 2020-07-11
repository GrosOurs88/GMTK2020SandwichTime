using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;


[XmlRoot("IdeaCollection")]
public class IdeasContainer
{    
    [XmlArray("Ideas")]
    [XmlArrayItem("Idea")]
    public List<Idea> ideas = new List<Idea>();

    private static string Path = Application.streamingAssetsPath + "IdeaCollection.xml";

    public void Save()
    {
        var serializer = new XmlSerializer(typeof(IdeasContainer));

        using (var stream = new FileStream(Path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static IdeasContainer Load()
    {
        var serializer = new XmlSerializer(typeof(IdeasContainer));
        
        return serializer.Deserialize(new FileStream(Path, FileMode.Open)) as IdeasContainer;
    }

    public void CreateTemplate()
    {
        ideas = new List<Idea>();

        ideas.Add(new Idea());

        Save();
    }
}
