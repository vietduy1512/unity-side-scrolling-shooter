using UnityEngine;

public class BossBullet01 : MonoBehaviour
{
    [SerializeField] float delayShoot = 3f;

    void Start()
    {

    }

    void Update()
    {
        delayShoot -= Time.deltaTime;

        if (delayShoot < 0)
        {
            gameObject.GetComponent<MoveForward>().enabled = true;
            gameObject.GetComponent<FacesPlayer>().enabled = false;
            gameObject.GetComponent<BossBullet01>().enabled = false;
        }
    }
}
