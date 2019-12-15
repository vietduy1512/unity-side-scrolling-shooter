using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    public static int upgradePoint = 0;

    public void IncreaseUpgradePoint(int value)
    {
        upgradePoint += value;
        this.gameObject.GetComponent<Text>().text = upgradePoint.ToString();
    }

    public void DecreaseUpgradePoint(int value)
    {
        upgradePoint -= value;
        this.gameObject.GetComponent<Text>().text = upgradePoint.ToString();
    }
}
