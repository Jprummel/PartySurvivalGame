using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRain : Ability {

    [SerializeField]private GameObject _landingCircle;
    private GameObject _circle;

    public override void UseAbility()
    {
        if (!_usingAbility)
        {
            StartTargeting();
        }
    }

    public override void CancelAbility()
    {
        CancelTargeting();
    }

    void Start()
    {
        _abilityIsReady = true;
    }

    void Update()
    {
        if (Input.GetAxis(InputAxes.RIGHT_JOYSTICK_X + _player.PlayerID) != 0 || Input.GetAxis(InputAxes.RIGHT_JOYSTICK_Y + _player.PlayerID) != 0)
        {
            float x = Input.GetAxis(InputAxes.RIGHT_JOYSTICK_X + _player.PlayerID);
            float y = Input.GetAxis(InputAxes.RIGHT_JOYSTICK_Y + _player.PlayerID);
            Vector2 moveDir = new Vector2(x, y).normalized;
            _circle.transform.Translate(moveDir);
        }
    }

    void StartTargeting()
    {
        //distance from circle to player
        float Offset = 3;
        if(transform.rotation.y > 0)
        {
            //make the circle match the direction the player is facing
            Offset = -Offset;
        }
        //set the position of the targeting circle
        Vector2 circlePos = new Vector2(transform.position.x + Offset, transform.position.y);
        _circle = Instantiate(_landingCircle, circlePos, Quaternion.identity, this.transform);
        _usingAbility = true;
    }

    void CancelTargeting()
    {
        DestroyImmediate(_circle);
        _usingAbility = false;
    }
}
