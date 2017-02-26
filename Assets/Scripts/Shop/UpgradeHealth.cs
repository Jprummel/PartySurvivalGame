﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHealth : ShopItem, IUpgrade {

    public void Upgrade(PlayerCharacter player)
    {
        if (_cost <= player.Gold)
        {
            player.MaxHealth = Mathf.Round(player.MaxHealth * 1.1f);
            player.Gold -= _cost;
            DetermineNewCost();
        }
    }

    public void DetermineNewCost()
    {
        _cost = Mathf.Round(_cost * 1.15f);
    }
}
