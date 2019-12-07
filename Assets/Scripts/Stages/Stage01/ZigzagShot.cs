using UnityEngine;

public class ZigzagShot : MonoBehaviour
{
    [SerializeField] float rotSpeed = 0.1f;

    [SerializeField] float degree = 180f;

    float degreeCondition;

    void Start()
    {
        degreeCondition = degree;
        transform.Rotate(0, 0, degree / 2);
    }

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
