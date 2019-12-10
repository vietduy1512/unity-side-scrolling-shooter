using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public float speed = 0.1f;

    void Update()
    {
        float x = Mathf.Repeat(Time.time * speed, 1);
        Vector2 offset = new Vector2(x, 0);
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}