using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeManager : MonoBehaviour
{
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


    public static float fireRate;
    public static float moveSpeed;
    public static float health;
    public static int maxBarretts;
    public static int maxShields;

    private void Awake()
    {
        fireRate = initFireRate;
        moveSpeed = initMoveSpeed;
        health = initHealth;
        maxBarretts = initMaxBarretts;
        maxShields = initMaxShields;
    }

    public void upgradeFireDelay()
    {
        fireRate += fireRateUpgradeOffset;
    }

    public void upgradeMoveSpeed()
    {
        moveSpeed += moveSpeedUpgradeOffset;
    }

    public void upgradeHealth()
    {
        health += healthUpgradeOffset;
    }

    public void upgradeBarrett()
    {
        maxBarretts += maxBarrettsOffset;
    }

    public void upgradeMaxShields()
    {
        maxShields += maxShieldsOffset;
    }
}
