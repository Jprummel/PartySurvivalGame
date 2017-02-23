using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHealth : ShopItem, IUpgrade {

    public void Upgrade(PlayerCharacter character)
    {
        if (_cost <= character.Gold)
        {
            character.MaxHealth = character.MaxHealth * 1.1f;
            character.Gold -= _cost;
        }
    }

    public void DetermineNewCost()
    {

    }
}
