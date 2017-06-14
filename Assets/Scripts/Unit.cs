using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour {

    private Enemy _enemy;
    private Rigidbody2D _rgb2d;
    public Transform target;
    Vector3[] path;
    int targetIndex;

    void Start()
    {
        _enemy = GetComponent<Enemy>();
        _rgb2d = GetComponent<Rigidbody2D>();
        InvokeRepeating("FindPath", 0.01f, 0.25f);
    }

    void FindPath()
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
            if (transform.position == currentWaypoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            if (distance > _enemy.AttackRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, _enemy.MovementSpeed / 100);
                _rgb2d.velocity = Vector2.zero;
            }
            yield return null;
        }
    }
}
