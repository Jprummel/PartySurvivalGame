using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHealth : ShopItem, IUpgrade {

    public void Upgrade()
    {
        if (_cost <= _display.MatchingPlayer.Gold)
        {
            _display.MatchingPlayer.MaxHealth = Mathf.Round(_display.MatchingPlayer.MaxHealth * 1.1f);
            _display.MatchingPlayer.Gold -= _cost;
            _display.MatchingPlayer.HealthLevel++;
            DetermineNewCost();
        }
    }

    public void DetermineNewCost()
    {
        _cost = Mathf.Round(_cost * (_display.MatchingPlayer.HealthLevel * 1.15f));
        /*for (int i = 0; i < _playerUpgradeInfo.Count; i++)
        {
            if (_display.MatchingPlayer.PlayerID == _playerUpgradeInfo[i].UpgradeInfoID)
            {
                _playerUpgradeInfo[i].CurrentHealthCost = _cost;
            }
        }*/
        _display.MatchingPlayer.CurrentHealthCost = _cost;
    }

    public void GetCurrentCost()
    {
        /*for (int i = 0; i < _playerUpgradeInfo.Count; i++)
        {
            if (_playerUpgradeInfo[i].UpgradeInfoID == _display.MatchingPlayer.PlayerID)
            {
                _cost = _playerUpgradeInfo[i].CurrentHealthCost;
            }
        }*/
        Debug.Log(_display.MatchingPlayer.CurrentHealthCost);
        _cost = _display.MatchingPlayer.CurrentHealthCost;
    }
}
