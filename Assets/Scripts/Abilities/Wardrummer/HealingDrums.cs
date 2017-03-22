using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingDrums : Ability {

    private bool _keepDrumming;
    private bool _mustPressLeftTrigger;
    private bool _mustPressRightTrigger;

	void Start () {
        _abilityIsReady = true;
	}
	
    public override void UseAbility()
    {
        Debug.Log("Feel da healing beat");
        _cooldown = _maxCooldown;
        _abilityIsReady = false;
    }

    void StartDrumRhythm()
    {

    }
}
