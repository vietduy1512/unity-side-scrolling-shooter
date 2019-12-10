using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] GameObject Win;

    [SerializeField] float time = 100;

    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length == 0)
            {
                Invoke("Wining", 1f);
                GetComponent<WinCondition>().enabled = false;
            }
        }
    }

    void Wining()
    {
        Win.SetActive(true);
    }
}
