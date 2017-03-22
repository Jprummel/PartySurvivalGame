using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrows : MonoBehaviour {

    private Vector2 _targetLocation;

	void Start () {
        _targetLocation = transform.parent.position;
	}
	
	void Update () {
        Move();
	}

    void Move()
    {
        if(transform.position != transform.parent.position)
        {
            var dir = transform.parent.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        transform.position = Vector2.MoveTowards(transform.position, _targetLocation, 0.75f);
    }
}
