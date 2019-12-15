using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgradeManager : MonoBehaviour
{
    [SerializeField] GameObject upgradeScreen;
    [SerializeField] Point point;

    [Header("Upgrade Initilize")]
    [SerializeField] float initFireRate = 0.3f;
    [SerializeField] float initMoveSpeed = 8f;
    [SerializeField] float initHealth = 5;
    [SerializeField] int initMaxBarretts = 0;
    [SerializeField] int initMaxShields = 0;
    [SerializeField] int initFocusShooting = 0;

    [SerializeField] float fireRateUpgradeOffset = -0.05f;
    [SerializeField] float moveSpeedUpgradeOffset = 1f;
    [SerializeField] float healthUpgradeOffset = 5;
    [SerializeField] int maxBarrettsOffset = 1;
    [SerializeField] int maxShieldsOffset = 1;
    [SerializeField] int focusShootingOffset = 1;

    [SerializeField] int fireRateUpgradePoint = 5;
    [SerializeField] int moveSpeedUpgradePoint = 5;
    [SerializeField] int healthUpgradePoint = 2;
    [SerializeField] int maxBarrettsUpgradePoint = 10;
    [SerializeField] int maxShieldsUpgradePoint = 10;
    [SerializeField] int focusShootingUpgradePoint = 10;

    [Header("Upgrade UI")]
    [SerializeField] GameObject fireRateUpgradePointLabel;
    [SerializeField] GameObject moveSpeedUpgradePointLabel;
    [SerializeField] GameObject healthUpgradePointLabel;
    [SerializeField] GameObject maxBarrettsUpgradePointLabel;
    [SerializeField] GameObject maxShieldsUpgradePointLabel;
    [SerializeField] GameObject focusShootingUpgradePointLabel;

    public static int fireRateCount = 0;
    public static int moveSpeedCount = 0;
    public static int healthCount = 0;
    public static int maxBarrettsCount = 0;
    public static int maxShieldsCount = 0;
    public static int focusShootingCount = 0;

    public static float fireRate;
    public static float moveSpeed;
    public static float health;
    public static int maxBarretts;
    public static int maxShields;
    public static int focusShooting;

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

    public void upgradeFireRate()
    {
        if (Point.upgradePoint - GetFireRatePoint() < 0)
        {
            return;
        }
        point.DecreaseUpgradePoint(GetFireRatePoint());
        fireRate += fireRateUpgradeOffset;
        fireRateCount++;
        ChangeLevelText("FireRateLevelCount", fireRateCount);
        fireRateUpgradePointLabel.GetComponent<Text>().text = GetFireRatePoint().ToString();
    }

    public void upgradeMoveSpeed()
    {
        if (Point.upgradePoint - GetMoveSpeedPoint() < 0)
        {
            return;
        }
        point.DecreaseUpgradePoint(GetMoveSpeedPoint());
        moveSpeed += moveSpeedUpgradeOffset;
        moveSpeedCount++;
        ChangeLevelText("MoveSpeedLevelCount", moveSpeedCount);
        moveSpeedUpgradePointLabel.GetComponent<Text>().text = GetMoveSpeedPoint().ToString();
    }

    public void upgradeHealth()
    {
        if (Point.upgradePoint - GetHealthPoint() < 0)
        {
            return;
        }
        point.DecreaseUpgradePoint(GetHealthPoint());
        health += healthUpgradeOffset;
        healthCount++;
        ChangeLevelText("HealthLevelCount", healthCount);
        healthUpgradePointLabel.GetComponent<Text>().text = GetHealthPoint().ToString();
    }

    public void upgradeBarrett()
    {
        if (Point.upgradePoint - GetBarrettPoint() < 0)
        {
            return;
        }
        point.DecreaseUpgradePoint(GetBarrettPoint());
        maxBarretts += maxBarrettsOffset;
        maxBarrettsCount++;
        ChangeLevelText("BarrettLevelCount", maxBarrettsCount);
        maxBarrettsUpgradePointLabel.GetComponent<Text>().text = GetBarrettPoint().ToString();
    }

    public void upgradeMaxShields()
    {
        if (Point.upgradePoint - GetMaxShieldsPoint() < 0)
        {
            return;
        }
        point.DecreaseUpgradePoint(GetMaxShieldsPoint());
        maxShields += maxShieldsOffset;
        maxShieldsCount++;
        ChangeLevelText("ShieldLevelCount", maxShieldsCount);
        maxShieldsUpgradePointLabel.GetComponent<Text>().text = GetMaxShieldsPoint().ToString();
    }

    public void upgradeFocusShooting()
    {
        if (Point.upgradePoint - GetFocusShootingPoint() < 0)
        {
            return;
        }
        point.DecreaseUpgradePoint(GetFocusShootingPoint());
        focusShooting += focusShootingOffset;
        focusShootingCount++;
        ChangeLevelText("FocusShotLevelCount", focusShootingCount);
        focusShootingUpgradePointLabel.GetComponent<Text>().text = GetFocusShootingPoint().ToString();
    }

    private void ChangeLevelText(string name, int count)
    {
        GameObject.Find(name).GetComponent<Text>().text = "Level: " + count;
    }

    public int GetFireRatePoint() => fireRateUpgradePoint * (int)Mathf.Pow(2, fireRateCount);
    public int GetMoveSpeedPoint() => moveSpeedUpgradePoint * (int)Mathf.Pow(2, moveSpeedCount);
    public int GetHealthPoint() => healthUpgradePoint * (int)Mathf.Pow(2, healthCount);
    public int GetBarrettPoint() => maxBarrettsUpgradePoint * (int)Mathf.Pow(2, maxBarrettsCount);
    public int GetMaxShieldsPoint() => maxShieldsUpgradePoint * (int)Mathf.Pow(2, maxShieldsCount);
    public int GetFocusShootingPoint() => focusShootingUpgradePoint * (int)Mathf.Pow(2, focusShootingCount);

    void InitUpgradeUI()
    {
        upgradeScreen.SetActive(true);

        ChangeLevelText("FireRateLevelCount", fireRateCount);
        ChangeLevelText("MoveSpeedLevelCount", moveSpeedCount);
        ChangeLevelText("HealthLevelCount", healthCount);
        ChangeLevelText("BarrettLevelCount", maxBarrettsCount);
        ChangeLevelText("ShieldLevelCount", maxShieldsCount);
        ChangeLevelText("FocusShotLevelCount", focusShootingCount);

        fireRateUpgradePointLabel.GetComponent<Text>().text = GetFireRatePoint().ToString();
        moveSpeedUpgradePointLabel.GetComponent<Text>().text = GetMoveSpeedPoint().ToString();
        healthUpgradePointLabel.GetComponent<Text>().text = GetHealthPoint().ToString();
        maxBarrettsUpgradePointLabel.GetComponent<Text>().text = GetBarrettPoint().ToString();
        maxShieldsUpgradePointLabel.GetComponent<Text>().text = GetMaxShieldsPoint().ToString();
        focusShootingUpgradePointLabel.GetComponent<Text>().text = GetFocusShootingPoint().ToString();

        upgradeScreen.SetActive(false);
    }
}
