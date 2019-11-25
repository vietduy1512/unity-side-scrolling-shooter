using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;

    GameObject playerInstance;

    int correctLayer;

    public int Lives = 4;
    int numLives;

    float respawnTimer;

    //Reference to the lives ui text
    public Text LivesUIText;

    public GameObject GameOver;

    // Use this for initialization
    public void Start()
    {
        numLives = Lives;

        //update the lives UI text
        LivesUIText.text = numLives.ToString();

        //active player ?? 
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        numLives--;
        respawnTimer = 1;

        //Show number of lives left
        LivesUIText.text = numLives.ToString();

        DeleteWall();

        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInstance == null && numLives > 0)
        {
            respawnTimer -= Time.deltaTime;

            if (respawnTimer <= 0)
            {
                SpawnPlayer();
            }
        }
        else if (playerInstance == null && numLives == 0)
        {
            gameObject.SetActive(false);
            //Change to Game Over 
            GameOver.SetActive(true);
            // Procedure back to stages selection
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    void DeleteWall()
    {
        GameObject[] GO = GameObject.FindGameObjectsWithTag("Wall");
        for (int i = 0; i < GO.Length; i++)
        {

            Destroy(GO[i]);
        }
    }
}
