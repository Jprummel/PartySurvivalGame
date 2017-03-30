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
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == Tags.ENEMY)
        {
            ExecuteEvents.Execute<IDamageable>(target.gameObject, null, (x, y) => x.TakeDamage(_source));
        }
    }
}
