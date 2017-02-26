using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Author : Jordi Prummel

public class DisplayUpgradeInfo : MonoBehaviour {

    [SerializeField]private ShopItem    _upgradeType;
    [SerializeField]private Text        _upgradeTypeText;
    [SerializeField]private Text        _costText;

	void Start () {
        DisplayUpgradeType();
	}
	
	void Update () {
        DisplayUpgradeCost();
	}

    void DisplayUpgradeType()
    {
        _upgradeTypeText.text = "Upgrade " + _upgradeType.Name;
    }

    void DisplayUpgradeCost()
    {
        _costText.text = "Cost : " + _upgradeType.Cost; 
    }
}
