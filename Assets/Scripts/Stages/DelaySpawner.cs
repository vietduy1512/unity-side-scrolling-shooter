using UnityEngine;

public class DelaySpawner : MonoBehaviour
{
    public float delay;

    void Start()
    {

        gameObject.SetActive(false);
        Invoke("Spawn", delay);
    }

    void Spawn()
    {
        gameObject.SetActive(true);
    }
}
