using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeCosts : MonoBehaviour {

    private float _currrentDamageCost = 500;
    private float _currentHealthCost = 500;
    private float _currentMoveSpeedCost = 500;

    public float CurrentDamageCost
    {
        get { return _currrentDamageCost; }
        set { _currrentDamageCost = value; }
    }
    public float CurrentHealthCost
    {
        get { return _currentHealthCost; }
        set { _currentHealthCost = value; }
    }
    public float CurrentMoveSpeedCost
    {
        get { return _currentMoveSpeedCost; }
        set { _currentMoveSpeedCost = value; }
    }
}
