using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMovementSpeed : ShopItem, IUpgrade {

    public void Upgrade()
    {
        if (_cost <= _display.MatchingPlayer.Gold)
        {
            _display.MatchingPlayer.MovementSpeed = _display.MatchingPlayer.MovementSpeed + 0.25f;
            _display.MatchingPlayer.Gold -= _cost;
            DetermineNewCost();
        }
    }

    public void DetermineNewCost()
    {
        _cost = Mathf.Round(_cost * 1.5f);
    }
}
