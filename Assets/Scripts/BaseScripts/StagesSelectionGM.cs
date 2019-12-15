using UnityEngine;

public class StagesSelectionGM : MonoBehaviour
{
    public void StartStages(int level)
    {
        gameObject.GetComponent<StartOptions>().StartStages(level);
    }
}
