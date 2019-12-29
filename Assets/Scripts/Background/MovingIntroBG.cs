using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingIntroBG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        pos = new Vector2(pos.x, pos.y + 2 * Time.deltaTime);

        transform.position = pos;
    }
}
