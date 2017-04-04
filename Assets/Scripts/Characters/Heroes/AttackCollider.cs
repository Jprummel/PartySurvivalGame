using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackCollider : MonoBehaviour {

    Character _source;

    void Start()
    {
        if(_source == null)
        {
            _source = GetComponentInParent<Character>();
        }
    }

    public void GetSource(Character source)
    {
        _source = source;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
            if (_source.tag == Tags.PLAYER && target.tag == Tags.ENEMY)
            {
                ExecuteEvents.Execute<IDamageable>(target.gameObject, null, (x, y) => x.TakeDamage(_source));
            }
            if (_source.tag == Tags.ENEMY && target.tag == Tags.PLAYER)
            {
                ExecuteEvents.Execute<IDamageable>(target.gameObject, null, (x, y) => x.TakeDamage(_source));
            }
    }
}
