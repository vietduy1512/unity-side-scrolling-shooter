using UnityEngine;

public class ZoomInAndOut : MonoBehaviour
{
    public float scaleSpeed = 1f;

    public float zoomDelay = 0.5f;

    public float maxScale;
    public float minScale;

    float delay;
    bool isZoomIn = true;

    void Start()
    {
        delay = zoomDelay;
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            if (isZoomIn)
            {

                delay = zoomDelay;

                if (transform.localScale.x >= maxScale)
                {
                    isZoomIn = false;
                    return;
                }
                transform.localScale += new Vector3(0.01f * scaleSpeed, 0.01f * scaleSpeed, 0.01f * scaleSpeed);
            }
            else
            {

                delay = zoomDelay;

                if (transform.localScale.x <= minScale)
                {
                    isZoomIn = true;
                    return;
                }
                transform.localScale -= new Vector3(0.01f * scaleSpeed, 0.01f * scaleSpeed, 0.01f * scaleSpeed);
            }
        }
    }
}
