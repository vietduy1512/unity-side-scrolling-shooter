using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int initScore = 0;
    [SerializeField] Text scoreText;
    [SerializeField] Point point;

    public static int currentScore;

    PlayerSpawner player;

    private void Awake()
    {
        if (!StagesGM.isStartGame)
        {
            currentScore = initScore;
        }
        player = GameObject.Find("PlayerSpawner").GetComponent<PlayerSpawner>();
    }

    void Update()
    {
        scoreText.text = currentScore.ToString();
    }

    public void UpdateScore(int value)
    {
        if (player.isPlayerAlive())
        {
            point.IncreaseUpgradePoint(value);
            currentScore += value;
        }
    }
}
