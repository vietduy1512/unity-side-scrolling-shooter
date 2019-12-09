using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorceManager : MonoBehaviour
{
    public Text scoreText;
    public int currentScore = 0;
    public PlayerSpawner player;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = this.currentScore.ToString();
    }


    public void UpdateScore(int value)
    {
        if (player.isPlayerAlive())
        {
            this.currentScore += value;
        }
    }
}
