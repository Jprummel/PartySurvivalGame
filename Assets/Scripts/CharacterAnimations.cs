using UnityEngine;
using Spine.Unity;

public class CharacterAnimations : MonoBehaviour {

    private Character _character;
    private SkeletonAnimation _upperbody;
    private SkeletonAnimation _lowerbody;

    private void Awake()
    {
        _character = GetComponent<Character>();
        _upperbody = _character.UpperBody;
        _lowerbody = _character.LowerBody;
    }

    public void MoveAnimation()
    {
        _upperbody.AnimationName = SpineAnimationNames.WALK + _character.MoveStateName;
        _lowerbody.AnimationName = SpineAnimationNames.WALK + _character.MoveStateName;
    }

    public void PlayerAttackAnimation(int attackState)
    {
        switch (attackState)
        {
            case 1:
                _upperbody.state.SetAnimation(0, SpineAnimationNames.FOREHAND + _character.MoveStateName, false);
                break;
            case 2:
                _upperbody.state.SetAnimation(0, SpineAnimationNames.BACKHAND + _character.MoveStateName, false);
                break;
            case 3:
                _upperbody.state.SetAnimation(0,SpineAnimationNames.OVERHEAD + _character.MoveStateName, false);
                break;
        }
    }

    public void AbilityAnimation()
    {
        _upperbody.state.SetAnimation(0, SpineAnimationNames.ABILITY, false);
        _lowerbody.state.SetAnimation(0, SpineAnimationNames.ABILITY, false);
        _upperbody.state.AddAnimation(0, SpineAnimationNames.IDLE + _character.MoveStateName, true, 1);
        _lowerbody.state.AddAnimation(0, SpineAnimationNames.IDLE + _character.MoveStateName, true, 1);
    }

    public void IdleAnimation()
    {
        _upperbody.AnimationName = SpineAnimationNames.IDLE + _character.MoveStateName;
        _lowerbody.AnimationName = SpineAnimationNames.IDLE + _character.MoveStateName;
    }
}
