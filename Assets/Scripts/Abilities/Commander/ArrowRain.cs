using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowRain : Ability {

    [SerializeField]private GameObject _landingCircle;
    [SerializeField]private GameObject _arrows;
    private GameObject _circle;
    private Vector2 _arrowLocation;
    private Vector2 _leftPos;
    private Vector2 _rightPos;
    private float _travelTime = 0.55f;

    public override void UseAbility()
    {
        if (!_usingAbility && _abilityIsReady)
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
        //_abilityIsReady = true;
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
            if (Input.GetAxis(InputAxes.RIGHT_JOYSTICK_X + _player.PlayerID) != 0 || Input.GetAxis(InputAxes.RIGHT_JOYSTICK_Y + _player.PlayerID) != 0)
            {
                float x = Input.GetAxis(InputAxes.RIGHT_JOYSTICK_X + _player.PlayerID);
                float y = Input.GetAxis(InputAxes.RIGHT_JOYSTICK_Y + _player.PlayerID);
                Vector2 moveDir = new Vector2(x, y).normalized;
                _circle.transform.Translate(moveDir * 0.35f);
            }
        }
    }

    void StartTargeting()
    {
        _player.CanMove = false;
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
        }
        _player.CanMove = true;//player is able to move again
        _usingAbility = false;// player is not using ability anymore
        _abilityIsReady = false;//make the ability cooldown
        _cooldown = _maxCooldown;//reset cooldown time
    }

    void ConfirmTarget()
    {
        if (_circle.transform.position.x < transform.position.x)
        {//make the arrows come from the left if the circle is on the left side of the commander
            _arrowLocation = _rightPos;
        }
        else
        {//make the arrows come from the right side if the circle is on the right side of the commander
            _arrowLocation = _leftPos;
        }
        StartCoroutine(StartRain());
        CancelTargeting(false);
    }

    IEnumerator StartRain()
    {
        //instantiate arrows with targeting circle as parent
        GameObject arrows = Instantiate(_arrows, _arrowLocation, Quaternion.identity, _circle.transform);
        //wait for ~traveltime
        yield return new WaitForSeconds(_travelTime);
        //activate the collider so that it can deal damage
        StartCoroutine(SpecialAttackDamage(3f, 0.15f));
        ExecuteEvents.Execute<HandleCollider>(_circle, null, (x, y) => x.SwitchCollider(true));
        //leavve the collider on for a split second
        yield return new WaitForSeconds(0.25f);
        DestroyImmediate(_circle);
    }
}
