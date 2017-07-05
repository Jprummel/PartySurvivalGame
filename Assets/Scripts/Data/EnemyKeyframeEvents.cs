using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class EnemyKeyframeEvents : MonoBehaviour {

    EnemyAttack _enemyAttack;
    private SkeletonAnimation _anim;

    void Start () {
        _enemyAttack = GetComponentInParent<EnemyAttack>();
        _anim = GetComponent<SkeletonAnimation>();
        _anim.state.Event += OnEvent;
    }

    private void OnEvent(Spine.TrackEntry trackEntry, Spine.Event e)
    {
        switch (e.Data.Name)
        {
            case KeyframeTags.HIT_START:

                break;
            case KeyframeTags.HIT_END:

                break;
            case KeyframeTags.ATTACK_END:
                _enemyAttack.FinishAttack();
                break;
            case KeyframeTags.ATTACK_ANIMATION_END:
                _enemyAttack.FinishAttackAnimation();
                break;
        }
    }
}
