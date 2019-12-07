using UnityEngine;

public class PlacingBarrett : MonoBehaviour
{
    [SerializeField] GameObject barrettPrefab1;

    [SerializeField] GameObject barrettPrefab2;

    [SerializeField] float placingCooldown = 5f;

    [SerializeField] int maxBarretts = 2;

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
