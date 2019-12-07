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

    public Text LivesUIText;

    public GameObject GameOver;

    public void Start()
    {
        numLives = Lives;
        LivesUIText.text = numLives.ToString();

        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        numLives--;
        respawnTimer = 1;

        LivesUIText.text = numLives.ToString();

        DeleteWall();

        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.Euler(0, 0, -90));
    }

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
            GameOver.SetActive(true);
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
