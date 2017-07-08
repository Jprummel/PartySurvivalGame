using UnityEngine;
using Spine.Unity;

public class KeyframeEvent : MonoBehaviour {

    private PlayerScriptCollector _playerScripts;
    private SkeletonAnimation _anim;

	void Start () {
        _anim = GetComponent<SkeletonAnimation>();
        _playerScripts = GetComponentInParent<PlayerScriptCollector>();
        _anim.state.Event += OnEvent;
	}

    private void OnEvent(Spine.TrackEntry trackEntry, Spine.Event e)
    {
        switch (e.Data.Name)
        {
            case KeyframeTags.LIGHT_ATTACK_END:
                _playerScripts.PlayerAttack.FinishLightAttack();
                break;
            case KeyframeTags.LIGHT_ATTACK_ANIMATION_END:
                _playerScripts.PlayerAttack.FinishAttackAnimation();
                break;
            case KeyframeTags.HEAVY_ATTACK_START:
                _playerScripts.PlayerAttack.StartHeavyAttack();
                break;
            case KeyframeTags.HEAVY_ATTACK_END:
                _playerScripts.PlayerAttack.FinishHeavyAttack();
                break;
            case KeyframeTags.HEAVY_ATTACK_ANIMATION_END:
                _playerScripts.PlayerAttack.FinishAttackAnimation();
                break;
            case KeyframeTags.WHIRLWIND_END:
                _playerScripts.Whirlwind.FinishWhirlwind();
                break;
            case KeyframeTags.CHARGE_START:

                break;
            case KeyframeTags.CHARGE_END:
                Debug.Log("keyframe event");
                _playerScripts.Charge.FinishCharge();
                break;
            case KeyframeTags.MARK_START:

                break;
            case KeyframeTags.MARK_END:
                _playerScripts.ArrowRain.FinishMark();
                break;
        }
    }
}
