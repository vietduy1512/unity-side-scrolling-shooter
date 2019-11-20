using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.1f;

    Material material;
    Vector2 offset;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(backgroundScrollSpeed, 0);
    }

    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
