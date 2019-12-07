using UnityEngine;

public class PlacingBarrett : MonoBehaviour
{
    public GameObject barrettPrefab1;

    public GameObject barrettPrefab2;

    public float placingCooldown = 5f;

    public int maxBarretts = 2;

    int i = 1;

    [HideInInspector] public int j = 0;

    float tempPlacingCd = 0;

    void Start()
    {
    }

    void Update()
    {
        tempPlacingCd -= Time.deltaTime;

        if (j >= maxBarretts)
            return;

        if ((Input.GetButtonDown("Barrett") || Input.GetMouseButton(1)) && tempPlacingCd <= 0)
        {
            tempPlacingCd = placingCooldown;
            if (i == 1)
            {
                Instantiate(barrettPrefab1, transform.position, transform.rotation);
                i++;
                j++;
            }
            else
            {
                Instantiate(barrettPrefab2, transform.position, transform.rotation);
                i--;
                j++;
            }
        }
    }
}
