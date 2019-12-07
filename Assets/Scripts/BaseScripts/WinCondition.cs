using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] GameObject Win;

    [SerializeField] GameObject[] Enemies = new GameObject[10];

    void Update()
    {

        for (int i = 0; i < Enemies.Length; i++)
        {

            if (Enemies[i] != null)
            {
                return;
            }
        }
        Invoke("Wining", 7f);
        GetComponent<WinCondition>().enabled = false;
    }

    void Wining()
    {
        Win.SetActive(true);
    }
}
