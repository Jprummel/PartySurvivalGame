using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        _upgradeTypeText.text = _upgradeType.Name;
    }

    void DisplayUpgradeCost()
    {
        if (!_upgradeType.MaxedOut)
        {
            _costText.text = _upgradeType.Cost.ToString();
        }
        else
        {
            _costText.text = "MAXED OUT";
        }
    }
}
