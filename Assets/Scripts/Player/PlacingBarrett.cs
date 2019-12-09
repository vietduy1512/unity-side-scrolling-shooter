using UnityEngine;

public class PlacingBarrett : MonoBehaviour
{
    [SerializeField] GameObject barrettPrefab1;

    [SerializeField] GameObject barrettPrefab2;

    [SerializeField] float placingCooldown = 5f;


    int barretIndex = 1;

    [HideInInspector] public int currentBarrettsCount = 0;

    float tempPlacingCd = 0;

    void Start()
    {
    }

    void Update()
    {
        tempPlacingCd -= Time.deltaTime;

        if (currentBarrettsCount >= PlayerUpgradeManager.maxBarretts)
            return;

        if ((Input.GetButtonDown("Barrett") || Input.GetMouseButton(1)) && tempPlacingCd <= 0)
        {
            tempPlacingCd = placingCooldown;
            Instantiate(barrettPrefab2, transform.position, transform.rotation);
            currentBarrettsCount++;
            //if (barretIndex == 1)
            //{
            //    Instantiate(barrettPrefab1, transform.position, transform.rotation);
            //    barretIndex++;
            //    currentBarrettsCount++;
            //}
            //else
            //{
            //    Instantiate(barrettPrefab2, transform.position, transform.rotation);
            //    barretIndex--;
            //    currentBarrettsCount++;
            //}
        }
    }
}
