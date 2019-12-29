using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int currentScore = 0;

    public StagesGM stagesGM;

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
