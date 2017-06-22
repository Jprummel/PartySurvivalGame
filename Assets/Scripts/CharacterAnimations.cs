using System.Collections;
using UnityEngine;
using Spine.Unity;

public class CharacterAnimations : MonoBehaviour {

    private Character _character;
    private SkeletonAnimation _upperbody;
    private SkeletonAnimation _lowerbody;

    private bool _isAttacking;

    private void Awake()
    {
        _character = GetComponent<Character>();
        _upperbody = _character.UpperBody;
        _lowerbody = _character.LowerBody;
    }

    public void MoveAnimation()
    {
        if (!_isAttacking)
        {
            _upperbody.AnimationName = SpineAnimationNames.WALK + _character.MoveStateName;
        }

        _lowerbody.AnimationName = SpineAnimationNames.WALK + _character.MoveStateName;
    }

    public void PlayerAttackAnimation(int attackState)
    {
        _isAttacking = true;
        switch (attackState)
        {
            case 1:
                _upperbody.state.SetAnimation(0, SpineAnimationNames.FOREHAND + _character.MoveStateName, false);
                StartCoroutine(ReturnAttack(1));
                break;
            case 2:
                _upperbody.state.SetAnimation(0, SpineAnimationNames.BACKHAND + _character.MoveStateName, false);
                StartCoroutine(ReturnAttack(1));
                break;
            case 3:
                _upperbody.state.SetAnimation(0,SpineAnimationNames.OVERHEAD + _character.MoveStateName, false);
                StartCoroutine(ReturnAttack(2));
                break;
        }
    }

    public void AbilityAnimation()
    {
        _isAttacking = true;
        _upperbody.state.SetAnimation(0, SpineAnimationNames.ABILITY, false);
        _lowerbody.state.SetAnimation(0, SpineAnimationNames.ABILITY, false);
        _upperbody.state.AddAnimation(0, SpineAnimationNames.IDLE + _character.MoveStateName, true, 1);
        _lowerbody.state.AddAnimation(0, SpineAnimationNames.IDLE + _character.MoveStateName, true, 1);
        StartCoroutine(ReturnAttack(2));
    }

    public void IdleAnimation()
    {
        _upperbody.state.AddAnimation(0,SpineAnimationNames.IDLE + _character.MoveStateName,true,0);//Test
        _lowerbody.state.AddAnimation(0, SpineAnimationNames.IDLE + _character.MoveStateName, true, 0);//Test
    }

    IEnumerator ReturnAttack(float time)
    {
        yield return new WaitForSeconds(time);
        _isAttacking = false;
    }
}
