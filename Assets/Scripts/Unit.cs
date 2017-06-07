using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    private Rigidbody2D _rgb2d;
    private Enemy _enemy;
    private bool _hasTarget;
    public Transform target;
    Vector3[] path;
    int targetIndex;

    void Start()
    {
        _enemy = GetComponent<Enemy>();
        _rgb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (target != null)
        {
            PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
        }
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccesful)
    {
        if (pathSuccesful)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0];
        float distance = Vector2.Distance(transform.position, target.position);

        while (true)
        {
            if(transform.position == currentWaypoint)
            {
                targetIndex++;
                if(targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            if (distance > _enemy.AttackRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, _enemy.MovementSpeed / 100);
            }
            /*Vector2 dir = (currentWaypoint - transform.position).normalized * _enemy.MovementSpeed;
            _rgb2d.velocity = dir;*/
            yield return null;
        }
    }

}
