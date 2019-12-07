using UnityEngine;

public class Boss02Bullet01 : MonoBehaviour
{
    int i = 0;
    GameObject previousGO;
    [SerializeField] GameObject[] GO = new GameObject[50];

    [SerializeField] int maxFrames = 9;

    float animated = 0.0828f;
    float timer;

    void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {

            for (; i <= maxFrames; i++)
            {

                if (i == maxFrames)
                {

                    i = 0;
                    return;
                }

                if (i == 0)
                {
                    if (previousGO != null)
                        previousGO.GetComponent<PolygonCollider2D>().enabled = false;
                }
                else
                    GO[i].GetComponent<PolygonCollider2D>().enabled = true;

                previousGO = GO[i];
                timer = animated;
            }
        }
    }
}
