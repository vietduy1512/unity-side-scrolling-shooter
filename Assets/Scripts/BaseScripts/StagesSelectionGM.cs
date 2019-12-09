using UnityEngine;

public class StagesSelectionGM : MonoBehaviour
{
    GameObject UIMenu;

    public void StartStages(int level)
    {
        UIMenu = GameObject.Find("UIMenu");
        UIMenu.GetComponent<StartOptions>().StartStages(level);
    }
}
