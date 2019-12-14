using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public Text scoretext;

    private void OnEnable()
    {
        scoretext.text = string.Format("Score: {0}", ScoreManager.currentScore);
    }
}
