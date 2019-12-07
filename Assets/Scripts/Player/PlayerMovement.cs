using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float maxSpeed = 5f;

    [SerializeField] bool isMoving = true;

    float shipBoundaryRadius = 0.5f;

    void Update()
    {
        if (!isMoving) return;

        Vector3 pos = transform.position;
        Vector3 velocity;

        var horMovement = Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;
        var verMovement = -Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;

        // SHIFT button to slow down
        if (Input.GetButton("Slow"))
        {
            velocity = new Vector3(verMovement / 4 , horMovement / 4, 0);
        }
        else
        {
            velocity = new Vector3(verMovement, horMovement, 0);
        }

        pos += transform.rotation * velocity;

        if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }
        if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x + shipBoundaryRadius > widthOrtho)
        {
            pos.x = widthOrtho - shipBoundaryRadius;
        }
        if (pos.x - shipBoundaryRadius < -widthOrtho)
        {
            pos.x = -widthOrtho + shipBoundaryRadius;
        }
        transform.position = pos;
    }
}
