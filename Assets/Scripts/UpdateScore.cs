using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public Text scoretext;
    public Text highScore;
    public Button okButton;
    public ScoreManager manager;

    void Start() 
    {
        okButton.enabled = false;
        scoretext.text = string.Format("Score: {0}", manager.currentScore);
        manager.HighScore();
        highScore.text = string.Format("Highscore: {0}", manager.HighScore());
        StartCoroutine(SaveGame(delegate()
        {
            okButton.enabled = true;
        }));
    }

    IEnumerator SaveGame(System.Action completion) 
    {
        yield return manager.SaveCurrentGame();
        Debug.Log("Finised saveGame " + Time.time);
        completion();
    }
}
