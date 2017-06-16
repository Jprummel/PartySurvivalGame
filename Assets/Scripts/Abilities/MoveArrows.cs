using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrows : MonoBehaviour {

    private float time = 0;
    private float timeToReachTarget = 0.5f;
    private Vector2 _targetLocation;
    private Vector2 _startingLocation;

	void Start () {
        _startingLocation = transform.position;
        _targetLocation = transform.parent.position;
    }
	
	void Update () {
        Move();
	}

    void Move()
    {
        time += Time.deltaTime / timeToReachTarget;

        if (transform.position != transform.parent.position)
        {
            var dir = transform.parent.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        transform.position = Vector2.Lerp(_startingLocation, _targetLocation, time);
    }
}
