using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDamage : ShopItem, IUpgrade {

    public void Upgrade()
    {
        if (_cost <= _display.MatchingPlayer.Gold)
        {
            _display.MatchingPlayer.Damage = Mathf.Round(_display.MatchingPlayer.Damage * 1.1f);           
            _display.MatchingPlayer.Gold -= _cost; //Reduces the players gold by the cost of the upgrade
            DetermineNewCost();
        }
    }

    public void DetermineNewCost()
    {
        _cost = Mathf.Round(_cost * 1.1f);
    }
}
