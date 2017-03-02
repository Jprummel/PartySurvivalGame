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
            _display.MatchingPlayer.MoveSpeedLevel++;
            DetermineNewCost();
        }
    }

    public void DetermineNewCost()
    {
        _cost = Mathf.Round(_cost * (_display.MatchingPlayer.MoveSpeedLevel * 1.5f));
        /*for (int i = 0; i < _playerUpgradeInfo.Count; i++)
        {
            if (_display.MatchingPlayer.PlayerID == _playerUpgradeInfo[i].UpgradeInfoID)
            {
                _playerUpgradeInfo[i].CurrentMoveSpeedCost = _cost;
            }
        }*/
        _display.MatchingPlayer.CurrentMoveSpeedCost = _cost;
    }

    public void GetCurrentCost()
    {
        /*for (int i = 0; i < _playerUpgradeInfo.Count; i++)
        {
            if (_playerUpgradeInfo[i].UpgradeInfoID == _display.MatchingPlayer.PlayerID)
            {
                _cost = _playerUpgradeInfo[i].CurrentMoveSpeedCost;
            }
        }*/
        _cost = _display.MatchingPlayer.CurrentMoveSpeedCost;
    }
}
