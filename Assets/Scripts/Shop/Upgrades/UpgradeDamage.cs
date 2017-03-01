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
            _display.MatchingPlayer.DamageLevel++;
            DetermineNewCost();
        }
    }

    public void DetermineNewCost()
    {
        _cost = Mathf.Round(_cost * (_display.MatchingPlayer.DamageLevel * 1.1f));
        /*for (int i = 0; i < _playerUpgradeInfo.Count; i++)
        {
            if (_display.MatchingPlayer.PlayerID == _playerUpgradeInfo[i].UpgradeInfoID)
            {
                _playerUpgradeInfo[i].CurrentDamageCost = _cost;
            }
        }*/
        _display.MatchingPlayer.CurrentDamageCost = _cost;
    }

    public void GetCurrentCost()
    {
        _cost = _display.MatchingPlayer.CurrentDamageCost; 
        /*for (int i = 0; i < _playerUpgradeInfo.Count; i++)
        {
            if (_playerUpgradeInfo[i].UpgradeInfoID == _display.MatchingPlayer.PlayerID)
            {
                _cost = _playerUpgradeInfo[i].CurrentDamageCost;
            }
        }*/
    }
}
