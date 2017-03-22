using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRain : Ability {

    [SerializeField]private GameObject _landingCircle;
    private GameObject _circle;

    public override void UseAbility()
    {
        StartTargeting();
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
        if(_circle != null)
        {
            Debug.Log("circle is active");
        }
    }

    void StartTargeting()
    {
        Vector2 circlePos = new Vector2(transform.position.x + 3, transform.position.y);
        _circle = Instantiate(_landingCircle, circlePos, Quaternion.identity, this.transform);
        _usingAbility = true;
    }

    void CancelTargeting()
    {
        DestroyImmediate(_circle);
        _usingAbility = false;
    }
}
