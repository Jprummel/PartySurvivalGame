using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMovementSpeed : ShopItem, IUpgrade {

    void LateUpdate()
    {
        CheckIfMaxed();
    }

    void CheckIfMaxed()
    {
        if (_display.MatchingPlayer.MovementSpeed < 12.5)
        {
            _maxedOut = false;
        }
        else if (_display.MatchingPlayer.MovementSpeed >= 12.5)
        {
            _maxedOut = true;
        }
    }

    public void Upgrade()
    {
        if (_cost <= _display.MatchingPlayer.Gold && !_maxedOut)
        {
            _soundEffects.PlayBuySound();
            _display.MatchingPlayer.MovementSpeed = _display.MatchingPlayer.MovementSpeed + 0.25f;
            _display.MatchingPlayer.Gold -= _cost;
            DetermineNewCost();            
        }
    }

    public void DetermineNewCost()
    {
        _cost = Mathf.Round(_cost * 1.5f);
        _display.MatchingPlayer.UpgradeCosts.CurrentMoveSpeedCost = _cost;
    }

    public void GetCurrentCost()
    {
        _cost = _display.MatchingPlayer.UpgradeCosts.CurrentMoveSpeedCost;
    }
}
