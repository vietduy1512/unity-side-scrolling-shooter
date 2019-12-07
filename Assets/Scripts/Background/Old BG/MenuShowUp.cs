using UnityEngine;

public class MenuShowUp : MonoBehaviour
{
    public float timer = 3.5f;

    public Animator animColorFade;

    Color startOptions;

    Vector3 pos;

    void Start()
    {

        pos = transform.position;
        gameObject.SetActive(false);
        Invoke("ShowAnimation", timer - 1f);
        Invoke("ShowMenu", timer);
    }

    void ShowAnimation()
    {
        gameObject.SetActive(true);
        animColorFade.SetTrigger("fade");
        transform.position = new Vector3(0, -400, 0);

    }

    void ShowMenu()
    {
        transform.position = pos;
    }
}
