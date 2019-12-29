using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class GameContainer
{
    [XmlArray("stages")]
    [XmlArrayItem("stage")]
    public List<Stage> stages = new List<Stage>();

    public string FindHighScore(string stage) {
        foreach(Stage value in stages) {
            if (value.Name == stage) {
                return value.Score;
            }
        }
        return "0";
    }

    public void Save(string stage, int score) {
        int selectedIndex = stages.FindIndex(e => e.Name == stage);

        if (selectedIndex != -1) {
            var selected = stages[selectedIndex];
            int selectedScore = 0;
            int.TryParse(selected.Score,out selectedScore);
            selected.Score = selectedScore.ToString();
            stages[selectedIndex] = selected;
        }
        else
        {
            var value = new Stage();
            value.Name = stage;
            value.Score = score.ToString();
            stages.Add(value);
        }
    }
}
