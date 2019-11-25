using UnityEngine;

public class ZigzagShot : MonoBehaviour
{
    public float rotSpeed = 0.1f;

    public float degree = 180f;

    float degreeCondition;

    void Start()
    {
        degreeCondition = degree;
        transform.Rotate(0, 0, degree / 2);
    }

    // Update is called once per frame
    void Update()
    {

        if (degreeCondition >= degree || degreeCondition <= -degree)
        {

            degreeCondition = 0;
            rotSpeed = -rotSpeed;
        }
        degreeCondition += rotSpeed;

        transform.Rotate(0, 0, rotSpeed);
    }
}
