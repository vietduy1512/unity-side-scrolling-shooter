using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DatabaseLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start loading xml");
        StartCoroutine(LoadDatabase(delegate() 
        {
            //Load start screen
            SceneManager.LoadScene("MainMenu");
        }));
    }

    IEnumerator LoadDatabase(System.Action finished)
    {
        yield return DatabaseManager.intance.InitDatabase();
        Debug.Log("Finised loading " + Time.time);
        finished();
    }
}
