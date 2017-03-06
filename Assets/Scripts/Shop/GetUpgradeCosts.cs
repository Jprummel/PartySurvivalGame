using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUpgradeCosts : MonoBehaviour {

    [SerializeField]private UpgradeDamage           _damageUpgrade;
    [SerializeField]private UpgradeHealth           _healthUpgrade;
    [SerializeField]private UpgradeMovementSpeed    _moveSpeedUpgrade;

    public void ShowPlayerUpgradeCosts()
    {
        _damageUpgrade.GetCurrentCost();
        _healthUpgrade.GetCurrentCost();
        _moveSpeedUpgrade.GetCurrentCost();
    }
}
