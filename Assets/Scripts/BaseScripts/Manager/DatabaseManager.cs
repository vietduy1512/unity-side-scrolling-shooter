using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using System.IO;

public class DatabaseManager : MonoBehaviour
{
    public GameContainer container;
    public static DatabaseManager intance = new DatabaseManager();

    private DatabaseManager()
    {
        container = new GameContainer();
    }

    //Must call when load 1st scence
    public bool InitDatabase()
    {
        if (Directory.Exists(DataConstant.databasePath))
        {
            this.container = LoadGame();
            Debug.Log(this.container);
        }
        else
        {
            Directory.CreateDirectory(DataConstant.databasePath);
            SaveGame();
        }
        return true;
    }

    public void SaveGame()
    {
        var serialize = new XmlSerializer(typeof(GameContainer));
        var stream = new FileStream(DataConstant.gameXmlPath, FileMode.Create);
        serialize.Serialize(stream, this.container);
        stream.Close();
    }

    private GameContainer LoadGame()
    {
        var serializer = new XmlSerializer(typeof(GameContainer));
        var stream = new FileStream(DataConstant.gameXmlPath, FileMode.OpenOrCreate);
        var container = serializer.Deserialize(stream) as GameContainer;
        stream.Close();
        return container;
    }
}

public class DataConstant
{
    public static string databasePath = Path.Combine(Application.persistentDataPath, "database");
    public static string gameXmlPath = Path.Combine(databasePath, "games.xml");
}