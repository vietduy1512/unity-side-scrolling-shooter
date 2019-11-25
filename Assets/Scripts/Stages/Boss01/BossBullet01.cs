using UnityEngine;

public class BossBullet01 : MonoBehaviour
{
    public float delayShoot = 3f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
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
