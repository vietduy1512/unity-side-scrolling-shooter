using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgradeManager : MonoBehaviour
{
    [SerializeField] GameObject upgradeScreen;

    [Header("Upgrade Initilize")]
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

    [SerializeField] int fireRateUpgradePoint = 5;
    [SerializeField] int moveSpeedUpgradePoint = 5;
    [SerializeField] int healthUpgradePoint = 2;
    [SerializeField] int maxBarrettsUpgradePoint = 10;
    [SerializeField] int maxShieldsUpgradePoint = 10;

    [Header("Upgrade UI")]
    [SerializeField] GameObject fireRateUpgradePointLabel;
    [SerializeField] GameObject moveSpeedUpgradePointLabel;
    [SerializeField] GameObject healthUpgradePointLabel;
    [SerializeField] GameObject maxBarrettsUpgradePointLabel;
    [SerializeField] GameObject maxShieldsUpgradePointLabel;

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
        fireRateUpgradePointLabel.GetComponent<Text>().text = GetFireRatePoint().ToString();
        fireRate += fireRateUpgradeOffset;
    }

    public void upgradeMoveSpeed()
    {
        moveSpeedCount++;
        ChangeLevelText("MoveSpeedLevelCount", moveSpeedCount);
        moveSpeedUpgradePointLabel.GetComponent<Text>().text = GetMoveSpeedPoint().ToString();
        moveSpeed += moveSpeedUpgradeOffset;
    }

    public void upgradeHealth()
    {
        healthCount++;
        ChangeLevelText("HealthLevelCount", healthCount);
        healthUpgradePointLabel.GetComponent<Text>().text = GetHealthPoint().ToString();
        health += healthUpgradeOffset;
    }

    public void upgradeBarrett()
    {
        maxBarrettsCount++;
        ChangeLevelText("BarrettLevelCount", maxBarrettsCount);
        maxBarrettsUpgradePointLabel.GetComponent<Text>().text = GetBarrettPoint().ToString();
        maxBarretts += maxBarrettsOffset;
    }

    public void upgradeMaxShields()
    {
        maxShieldsCount++;
        ChangeLevelText("ShieldLevelCount", maxShieldsCount);
        maxShieldsUpgradePointLabel.GetComponent<Text>().text = GetMaxShieldsPoint().ToString();
        maxShields += maxShieldsOffset;
    }

    private void ChangeLevelText(string name, int count)
    {
        GameObject.Find(name).GetComponent<Text>().text = "Level: " + count;
    }

    public int GetFireRatePoint() => fireRateUpgradePoint * (fireRateCount + 1);
    public int GetMoveSpeedPoint() => moveSpeedUpgradePoint * (moveSpeedCount + 1);
    public int GetHealthPoint() => healthUpgradePoint * (healthCount + 1);
    public int GetBarrettPoint() => maxBarrettsUpgradePoint * (maxBarrettsCount + 1);
    public int GetMaxShieldsPoint() => maxShieldsUpgradePoint * (maxShieldsCount + 1);

    void InitUpgradeUI()
    {
        upgradeScreen.SetActive(true);

        ChangeLevelText("FireRateLevelCount", fireRateCount);
        ChangeLevelText("MoveSpeedLevelCount", moveSpeedCount);
        ChangeLevelText("HealthLevelCount", healthCount);
        ChangeLevelText("BarrettLevelCount", maxBarrettsCount);
        ChangeLevelText("ShieldLevelCount", maxShieldsCount);

        fireRateUpgradePointLabel.GetComponent<Text>().text = GetFireRatePoint().ToString();
        moveSpeedUpgradePointLabel.GetComponent<Text>().text = GetMoveSpeedPoint().ToString();
        healthUpgradePointLabel.GetComponent<Text>().text = GetHealthPoint().ToString();
        maxBarrettsUpgradePointLabel.GetComponent<Text>().text = GetBarrettPoint().ToString();
        maxShieldsUpgradePointLabel.GetComponent<Text>().text = GetMaxShieldsPoint().ToString();

        upgradeScreen.SetActive(false);
    }
}
