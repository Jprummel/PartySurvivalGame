using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpineDirectionalAnimation : StateMachineBehaviour {

    [SerializeField] private string _animName;
    [SerializeField] private bool _loop;
    [SerializeField] private bool _isAttack;
    SkeletonAnimation anim;
    Character _char;
    string direction;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        anim = animator.GetComponent<SkeletonAnimation>();
        _char = animator.GetComponentInParent<Character>();
        anim.state.SetAnimation(0, _animName + "_" + _char.MoveStateName, _loop);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_char.MoveStateName != direction && !_isAttack)
        {
            Debug.Log(_animName + "_" + _char.MoveStateName);
            anim.state.SetAnimation(0, _animName + "_" + _char.MoveStateName, _loop);
            direction = _char.MoveStateName;
        }
    }
}
