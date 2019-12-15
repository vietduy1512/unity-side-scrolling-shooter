using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int initScore = 0;
    [SerializeField] Text scoreText;

    public static int currentScore;

    PlayerSpawner player;
    Point point;

    private void Awake()
    {
        if (!StagesGM.isStartGame)
        {
            currentScore = initScore;
        }
        player = GameObject.Find("PlayerSpawner").GetComponent<PlayerSpawner>();
        point = gameObject.GetComponentInChildren<Point>();
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
