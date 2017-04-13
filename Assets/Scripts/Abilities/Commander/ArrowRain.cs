using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowRain : Ability {

    private Quaternion _rotation;
    [SerializeField]private GameObject _landingCircle;
    [SerializeField]private GameObject _arrows;
    private GameObject _circle;
    private Vector2 _arrowLocation;
    private Vector2 _leftPos;
    private Vector2 _rightPos;
    private float _travelTime = 0.5f;

    public override void UseAbility()
    {
        if (!_usingAbility && _canUseAbility && _abilityIsReady)
        {
            //instantiate targeting circle
            StartTargeting();
        }
        //if the playing is using the targeting circle
        else if(_usingAbility && _abilityIsReady)
        {
            //confirm arrow location
            ConfirmTarget();
        }
    }

    public override void CancelAbility()
    {
        CancelTargeting(true);
    }

    void Start()
    {
        //upper left screen position
        _leftPos = Camera.main.ViewportToWorldPoint(new Vector2(0f, 1.1f));
        //upper right screen position
        _rightPos = Camera.main.ViewportToWorldPoint(new Vector2(1.1f, 1.1f));
    }

    protected override void Update()
    {
        //execute update in base class
        base.Update();
        //make the player able to move the targeting circle if its there
        if(_circle != null && _usingAbility)
        {
            _player.CanMove = false;
            if (Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _player.PlayerID) != 0 || Input.GetAxis(InputAxes.LEFT_JOYSTICK_Y + _player.PlayerID) != 0)
            {
                float x = Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _player.PlayerID);
                float y = Input.GetAxis(InputAxes.LEFT_JOYSTICK_Y + _player.PlayerID);
                Vector2 moveDir = new Vector2(x, y).normalized;
                _circle.transform.Translate(moveDir * 0.35f);
                //face player targetting side
                if(_circle.transform.position.x < transform.position.x)
                {
                    _rotation.y = 180;
                }
                else if(_circle.transform.position.x > transform.position.x)
                {
                    _rotation.y = 0;
                }
                transform.rotation = _rotation;
            }
        }
    }

    void StartTargeting()
    {
        _player.CanMove = false;
        _player.CharacterAnimator.SetBool("IsMoving",false);
        //distance from circle to player
        float Offset = 3;
        if(transform.rotation.y > 0)
        {
            //make the circle match the direction the player is facing
            Offset = -Offset;
        }
        //set the position of the targeting circle
        Vector2 circlePos = new Vector2(transform.position.x + Offset, transform.position.y);
        _circle = Instantiate(_landingCircle, circlePos, Quaternion.identity);
        AttackCollider collider = _circle.GetComponent<AttackCollider>();
        collider.GetSource(_player);
        _usingAbility = true;
    }

    void CancelTargeting(bool cancel)
    {
        if (cancel)
        {
            DestroyImmediate(_circle);//remove targeting circle
            _player.CanMove = true;
        }
        _usingAbility = false;// player is not using ability anymore
        _abilityIsReady = false;//make the ability cooldown
        _cooldown = _maxCooldown;//reset cooldown time
    }

    void ConfirmTarget()
    {
        //Makes the arrows appear from behind the commander
        if (transform.rotation.y == 1)
        {
            _arrowLocation = _rightPos;
        }
        else if(transform.rotation.y == 0)
        {
            _arrowLocation = _leftPos;
        }
        StartCoroutine(StartRain());
        CancelTargeting(false);
    }

    IEnumerator StartRain()
    {
        StartCoroutine(StartAnimation());
        //instantiate arrows with targeting circle as parent
        Instantiate(_arrows, _arrowLocation, Quaternion.identity, _circle.transform);
        _sound.PlayAbilitySound();
        //wait for traveltime
        yield return new WaitForSeconds(_travelTime);
        //activate the collider so that it can deal damage
        StartCoroutine(SpecialAttackDamage(3f, 0.15f));
        ExecuteEvents.Execute<HandleCollider>(_circle, null, (x, y) => x.SwitchCollider(true));
        //leave the collider on for a split second
        yield return new WaitForSeconds(0.25f);
        DestroyImmediate(_circle);
    }

    IEnumerator StartAnimation()
    {
        _player.CharacterAnimator.SetBool("CommandArchers", true);
        yield return new WaitForSeconds(0.75f);
        _player.CharacterAnimator.SetBool("CommandArchers", false);
        _player.CanMove = true;
    }
}
