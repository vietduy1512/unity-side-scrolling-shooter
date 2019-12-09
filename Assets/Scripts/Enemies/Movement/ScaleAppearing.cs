using UnityEngine;

public class ScaleAppearing : MonoBehaviour
{
    [SerializeField] float scaleSpeed = 1f;

    [SerializeField] float zoomDelay = 0.5f;

    float delay, maxScale;

    void Start()
    {

        delay = zoomDelay;
        scaleSpeed *= 0.1f;
        maxScale = transform.localScale.x;
        transform.localScale = new Vector3(0, 0, 0);
    }

    void Update()
    {

        delay -= Time.deltaTime;

        if (transform.localScale.x >= maxScale)
        {

            return;
        }
        else if (delay <= 0)
        {

            delay = zoomDelay;
            transform.localScale += new Vector3(scaleSpeed, scaleSpeed, scaleSpeed);
        }
    }
}
