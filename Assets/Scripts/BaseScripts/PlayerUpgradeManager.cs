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
    
    public static int FireRateLimit = 10;
    public static int MoveSpeedLimit = 10;
    public static int HealthLimit = 20;
    public static int MaxBarrettsLimit = 3;
    public static int MaxShieldsLimit = 3;
    public static int FocusShootingLimit = 2;

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
        if (Point.upgradePoint - GetFireRatePoint() < 0 || fireRateCount >= FireRateLimit)
        {
            return;
        }
        point.DecreaseUpgradePoint(GetFireRatePoint());
        fireRate += fireRateUpgradeOffset;
        fireRateCount++;
        ChangeLevelText("FireRateLevelCount", fireRateCount, FireRateLimit);
        ChangeUpgradeButtonText(fireRateUpgradePointLabel, GetFireRatePoint(), fireRateCount, FireRateLimit);
    }

    public void upgradeMoveSpeed()
    {
        if (Point.upgradePoint - GetMoveSpeedPoint() < 0 || moveSpeedCount >= MoveSpeedLimit)
        {
            return;
        }
        point.DecreaseUpgradePoint(GetMoveSpeedPoint());
        moveSpeed += moveSpeedUpgradeOffset;
        moveSpeedCount++;
        ChangeLevelText("MoveSpeedLevelCount", moveSpeedCount, MoveSpeedLimit);
        ChangeUpgradeButtonText(moveSpeedUpgradePointLabel, GetMoveSpeedPoint(), moveSpeedCount, MoveSpeedLimit);
    }

    public void upgradeHealth()
    {
        if (Point.upgradePoint - GetHealthPoint() < 0 || healthCount >= HealthLimit)
        {
            return;
        }
        point.DecreaseUpgradePoint(GetHealthPoint());
        health += healthUpgradeOffset;
        healthCount++;
        ChangeLevelText("HealthLevelCount", healthCount, HealthLimit);
        ChangeUpgradeButtonText(healthUpgradePointLabel, GetHealthPoint(), healthCount, HealthLimit);
    }

    public void upgradeBarrett()
    {
        if (Point.upgradePoint - GetBarrettPoint() < 0 || maxBarrettsCount >= MaxBarrettsLimit)
        {
            return;
        }
        point.DecreaseUpgradePoint(GetBarrettPoint());
        maxBarretts += maxBarrettsOffset;
        maxBarrettsCount++;
        ChangeLevelText("BarrettLevelCount", maxBarrettsCount, MaxBarrettsLimit);
        ChangeUpgradeButtonText(maxBarrettsUpgradePointLabel, GetBarrettPoint(), maxBarrettsCount, MaxBarrettsLimit);
    }

    public void upgradeMaxShields()
    {
        if (Point.upgradePoint - GetMaxShieldsPoint() < 0 || maxShieldsCount >= MaxShieldsLimit)
        {
            return;
        }
        point.DecreaseUpgradePoint(GetMaxShieldsPoint());
        maxShields += maxShieldsOffset;
        maxShieldsCount++;
        ChangeLevelText("ShieldLevelCount", maxShieldsCount, MaxShieldsLimit);
        ChangeUpgradeButtonText(maxShieldsUpgradePointLabel, GetMaxShieldsPoint(), maxShieldsCount, MaxShieldsLimit);
    }

    public void upgradeFocusShooting()
    {
        if (Point.upgradePoint - GetFocusShootingPoint() < 0 || focusShootingCount >= FocusShootingLimit)
        {
            return;
        }
        point.DecreaseUpgradePoint(GetFocusShootingPoint());
        focusShooting += focusShootingOffset;
        focusShootingCount++;
        ChangeLevelText("FocusShotLevelCount", focusShootingCount, FocusShootingLimit);
        ChangeUpgradeButtonText(focusShootingUpgradePointLabel, GetFocusShootingPoint(), focusShootingCount, FocusShootingLimit);
    }

    private void ChangeLevelText(string name, int count, int limit)
    {
        if (count >= limit)
        {
            GameObject.Find(name).GetComponent<Text>().text = "Level: MAX";
        }
        else
        {
            GameObject.Find(name).GetComponent<Text>().text = "Level: " + count;
        }
    }

    private void ChangeUpgradeButtonText(GameObject label, int value, int count, int limit)
    {
        if (count >= limit)
        {
            label.GetComponent<Text>().text = "X";
        }
        else
        {
            label.GetComponent<Text>().text = value.ToString();
        }
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

        ChangeLevelText("FireRateLevelCount", fireRateCount, FireRateLimit);
        ChangeLevelText("MoveSpeedLevelCount", moveSpeedCount, MoveSpeedLimit);
        ChangeLevelText("HealthLevelCount", healthCount, HealthLimit);
        ChangeLevelText("BarrettLevelCount", maxBarrettsCount, MaxBarrettsLimit);
        ChangeLevelText("ShieldLevelCount", maxShieldsCount, MaxShieldsLimit);
        ChangeLevelText("FocusShotLevelCount", focusShootingCount, FocusShootingLimit);

        fireRateUpgradePointLabel.GetComponent<Text>().text = GetFireRatePoint().ToString();
        moveSpeedUpgradePointLabel.GetComponent<Text>().text = GetMoveSpeedPoint().ToString();
        healthUpgradePointLabel.GetComponent<Text>().text = GetHealthPoint().ToString();
        maxBarrettsUpgradePointLabel.GetComponent<Text>().text = GetBarrettPoint().ToString();
        maxShieldsUpgradePointLabel.GetComponent<Text>().text = GetMaxShieldsPoint().ToString();
        focusShootingUpgradePointLabel.GetComponent<Text>().text = GetFocusShootingPoint().ToString();

        upgradeScreen.SetActive(false);
    }
}
