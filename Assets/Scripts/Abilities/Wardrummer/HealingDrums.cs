using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingDrums : Ability {

	// Use this for initialization
	void Start () {
        _abilityIsReady = true;
        _maxCooldown = 20;
	}
	
    public override void UseAbility()
    {
        Debug.Log("Feel da healing beat");
        _cooldown = _maxCooldown;
        _abilityIsReady = false;
    }
}
