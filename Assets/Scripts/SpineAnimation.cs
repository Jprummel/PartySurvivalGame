﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpineAnimation : StateMachineBehaviour {

    [SerializeField] private string _animName;
    [SerializeField] private float _speed;
    [SerializeField] private bool _loop;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SkeletonAnimation anim = animator.GetComponent<SkeletonAnimation>();
        Character _char = animator.GetComponentInParent<Character>();
        anim.state.SetAnimation(0, _animName + _char.MoveStateName, _loop).timeScale = _speed;
    }
}