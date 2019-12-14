using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgradeManager : MonoBehaviour
{
    [SerializeField] GameObject upgradeScreen;

    [SerializeField] float initFireRate = 0.3f;
    [SerializeField] float initMoveSpeed = 8f;
    [SerializeField] float initHealth = 5;
    [SerializeField] int initMaxBarretts = 0;
    [SerializeField] int initMaxShields = 0;

    [SerializeField] float fireRateUpgradeOffset = -0.05f;
    [SerializeField] float moveSpeedUpgradeOffset = 1f;
    [SerializeField] float healthUpgradeOffset = 5;
    [SerializeField] int maxBarrettsOffset = 1;
    [SerializeField] int maxShieldsOffset = 1;

    public static int fireRateCount = 0;
    public static int moveSpeedCount = 0;
    public static int healthCount = 0;
    public static int maxBarrettsCount = 0;
    public static int maxShieldsCount = 0;

    public static float fireRate;
    public static float moveSpeed;
    public static float health;
    public static int maxBarretts;
    public static int maxShields;

    private void Awake()
    {
        if (!StagesGM.isStartGame)
        {
            fireRate = initFireRate + fireRateUpgradeOffset * fireRateCount;
            moveSpeed = initMoveSpeed + moveSpeedUpgradeOffset * moveSpeedCount;
            health = initHealth + healthUpgradeOffset * healthCount;
            maxBarretts = initMaxBarretts + maxBarrettsOffset * maxBarrettsCount;
            maxShields = initMaxShields + maxBarrettsOffset * maxBarrettsCount;
        }
        InitUpgradeUI();
    }

    private void Start()
    {
    }

    public void upgradeFireRate()
    {
        fireRateCount++;
        ChangeLevelText("FireRateLevelCount", fireRateCount);
        fireRate += fireRateUpgradeOffset;
    }

    public void upgradeMoveSpeed()
    {
        moveSpeedCount++;
        ChangeLevelText("MoveSpeedLevelCount", moveSpeedCount);
        moveSpeed += moveSpeedUpgradeOffset;
    }

    public void upgradeHealth()
    {
        healthCount++;
        ChangeLevelText("HealthLevelCount", healthCount);
        health += healthUpgradeOffset;
    }

    public void upgradeBarrett()
    {
        maxBarrettsCount++;
        ChangeLevelText("BarrettLevelCount", maxBarrettsCount);
        maxBarretts += maxBarrettsOffset;
    }

    public void upgradeMaxShields()
    {
        maxShieldsCount++;
        ChangeLevelText("ShieldLevelCount", maxShieldsCount);
        maxShields += maxShieldsOffset;
    }

    private void ChangeLevelText(string name, int count)
    {
        GameObject.Find(name).GetComponent<Text>().text = "Level: " + count;
    }

    void InitUpgradeUI()
    {
        upgradeScreen.SetActive(true);

        ChangeLevelText("FireRateLevelCount", fireRateCount);
        ChangeLevelText("MoveSpeedLevelCount", moveSpeedCount);
        ChangeLevelText("HealthLevelCount", healthCount);
        ChangeLevelText("BarrettLevelCount", maxBarrettsCount);
        ChangeLevelText("ShieldLevelCount", maxShieldsCount);

        upgradeScreen.SetActive(false);
    }
}
