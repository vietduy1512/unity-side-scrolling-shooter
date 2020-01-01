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

    public StagesGM stagesGM;

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

    public string HighScore() {
        string currentStage = stagesGM.stageNumber.ToString();
        return DatabaseManager.intance.container.FindHighScore(currentStage);
    }

    public bool SaveCurrentGame() {
        string currentStage = stagesGM.stageNumber.ToString();
        DatabaseManager.intance.container.Save(currentStage, currentScore);
        DatabaseManager.intance.SaveGame();
        return true;
    }
}
