using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorceManager : MonoBehaviour
{
    public Text scoreText;
    public int currentScore = 0;

    PlayerSpawner player;

    private void Awake()
    {
        currentScore = 0;
        player = GameObject.Find("PlayerSpawner").GetComponent<PlayerSpawner>();
    }

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
