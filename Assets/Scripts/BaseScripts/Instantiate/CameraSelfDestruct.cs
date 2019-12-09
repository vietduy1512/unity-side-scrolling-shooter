using UnityEngine;

public class CameraSelfDestruct : MonoBehaviour
{
    float shipBoundaryRadius = -0.5f;

    void Start()
    {

    }

    void Update()
    {

        Vector3 pos = transform.position;

        if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
        if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x + shipBoundaryRadius > widthOrtho)
        {
            Destroy(gameObject);
        }
        if (pos.x - shipBoundaryRadius < -widthOrtho)
        {
            Destroy(gameObject);
        }
    }
}
