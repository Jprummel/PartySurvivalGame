using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHealth : ShopItem, IUpgrade {

    public void Upgrade()
    {
        if (_cost <= _display.MatchingPlayer.Gold)
        {
            _soundEffects.PlayBuySound();
            _display.MatchingPlayer.MaxHealth = Mathf.Round(_display.MatchingPlayer.MaxHealth * 1.1f);
            _display.MatchingPlayer.Gold -= _cost;
            DetermineNewCost();
        }
    }

    public void DetermineNewCost()
    {
        _cost = Mathf.Round(_cost * 1.15f);
        _display.MatchingPlayer.UpgradeCosts.CurrentHealthCost = _cost;
    }

    public void GetCurrentCost()
    {
        _cost = _display.MatchingPlayer.UpgradeCosts.CurrentHealthCost;
    }
}
