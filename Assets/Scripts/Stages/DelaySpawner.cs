using UnityEngine;

public class DelaySpawner : MonoBehaviour
{
    [SerializeField] float delay;

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
