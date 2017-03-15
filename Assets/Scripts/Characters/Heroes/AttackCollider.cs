using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackCollider : MonoBehaviour {

    PlayerCharacter _source;

    void Start()
    {
        _source = GetComponentInParent<PlayerCharacter>();
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        ExecuteEvents.Execute<IDamageable>(target.gameObject, null, (x, y) => x.TakeDamage(_source));
    }
}
