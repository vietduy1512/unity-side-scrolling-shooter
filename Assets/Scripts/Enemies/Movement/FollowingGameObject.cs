using UnityEngine;

public class FollowingGameObject : MonoBehaviour
{
    [SerializeField] Vector3 offset = new Vector3(0, 0.6f, 0);

    private Transform parent;

    void Start()
    {
        parent = GameObject.Find(gameObject.name).transform;
    }

    void Update()
    {
        transform.position = parent.position + offset;
    }
}
