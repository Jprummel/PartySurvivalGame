using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeInfo : MonoBehaviour {

    public int DamageLevel              { get; set; }
    public int HealthLevel              { get; set; }
    public int MoveSpeedLevel           { get; set; }
    public float CurrentDamageCost      { get; set; }
    public float CurrentHealthCost      { get; set; }
    public float CurrentMoveSpeedCost   { get; set; }

    public int UpgradeInfoID { get; set; }

    private PlayerCharacter _player;

    void Awake()
    {
        _player = GetComponent<PlayerCharacter>();
        UpgradeInfoID = _player.PlayerID;
    }
}
