using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMovementSpeed : ShopItem, IUpgrade {

    public void Upgrade(PlayerCharacter player)
    {
        if (_cost <= player.Gold)
        {
            player.MovementSpeed = player.MovementSpeed + 0.25f;
            player.Gold -= _cost;
            DetermineNewCost();
        }
    }

    public void DetermineNewCost()
    {
        _cost = Mathf.Round(_cost * 1.5f);
    }
}
