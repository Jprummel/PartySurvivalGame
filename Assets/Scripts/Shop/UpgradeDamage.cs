using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDamage : ShopItem, IUpgrade {

    public void Upgrade(PlayerCharacter character)
    {
        if (_cost <= character.Gold)
        {
            character.Damage = Mathf.Round(character.Damage * 1.1f);
            character.Gold -= _cost; //Reduces the players gold by the cost of the upgrade
            DetermineNewCost();
        }
    }

    public void DetermineNewCost()
    {
        _cost = Mathf.Round(_cost * 1.1f);
    }
}
