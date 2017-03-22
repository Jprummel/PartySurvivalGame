using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackCollider : MonoBehaviour {

    Character _source;

    void Start()
    {
        _source = GetComponentInParent<Character>();
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (_source.tag == Tags.PLAYER && target.tag == Tags.ENEMY)
        {
            Debug.Log(target);
            ExecuteEvents.Execute<IDamageable>(target.gameObject, null, (x, y) => x.TakeDamage(_source));
        }
        if (_source.tag == Tags.ENEMY && target.tag == Tags.PLAYER)
        {
            Debug.Log(target);
            ExecuteEvents.Execute<IDamageable>(target.gameObject, null, (x, y) => x.TakeDamage(_source));
        }
    }
}
