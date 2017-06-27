﻿using UnityEngine;
using Spine.Unity;

public class KeyframeEvent : MonoBehaviour {

    private PlayerScriptCollector _playerScripts;
    private SkeletonAnimation _anim;

	void Start () {
        _playerScripts = GetComponentInParent<PlayerScriptCollector>();
        _anim = GetComponent<SkeletonAnimation>();

        _anim.state.Event += OnEvent;
	}

    private void OnEvent(Spine.TrackEntry trackEntry, Spine.Event e)
    {
        switch (e.Data.Name)
        {
            case KeyframeTags.LIGHT_ATTACK_END:
                _playerScripts.PlayerAttack.FinishLightAttack();
                break;
            case KeyframeTags.HEAVY_ATTACK_START:
                _playerScripts.PlayerAttack.StartHeavyAttack();
                break;
            case KeyframeTags.HEAVY_ATTACK_END:
                _playerScripts.PlayerAttack.FinishHeavyAttack();
                break;
            /*case KeyframeTags.WHIRLWIND_START:
                
                break;*/
            case KeyframeTags.WHIRLWIND_END:
                _playerScripts.Whirlwind.FinishWhirlwind();
                break;
            case KeyframeTags.CHARGE_START:

                break;
            case KeyframeTags.CHARGE_END:
                _playerScripts.Charge.FinishCharge();
                break;
            case KeyframeTags.MARK_START:

                break;
            case KeyframeTags.MARK_END:
                _playerScripts.ArrowRain.FinishMark();
                break;
            case KeyframeTags.HIT_START:
                
                break;
            case KeyframeTags.HIT_END:

                break;
        }
    }
}