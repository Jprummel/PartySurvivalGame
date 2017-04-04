using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChargeCollider : MonoBehaviour {

    Character _source;

	void Start () {
        if (_source == null)
        {
            _source = GetComponentInParent<Character>();
        }
    }

    void Update()
    {
        if(_source.tag == Tags.ENEMY)
        {
            transform.gameObject.layer = LayerMask.NameToLayer("EnemyCharge");
        }
    }
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D target)
    {
        if (_source.tag != target.gameObject.tag)
        {
            ExecuteEvents.Execute<IDamageable>(target.gameObject, null, (x, y) => x.TakeDamage(_source));
        }
    }
}
