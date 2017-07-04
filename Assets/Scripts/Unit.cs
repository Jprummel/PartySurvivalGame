using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour {

    private bool _isMoving = false;
    private Enemy _enemy;
    private Rigidbody2D _rgb2d;
    public Transform target;
    Vector3[] path;
    int targetIndex;
    private bool _isAttacking;

    void Start()
    {
        _enemy = GetComponent<Enemy>();
        _rgb2d = GetComponent<Rigidbody2D>();
        InvokeRepeating("FindPath", 0.01f, 0.25f);
    }

    void FindPath()
    {
        if (target != null && !_enemy.IsDead)
        {
            PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
        }
        if (_isMoving)
        {
            _enemy.UpperBodyAnimator.SetBool("IsWalking", true);
            _enemy.LowerBodyAnimator.SetBool("IsWalking", true);
        }
        else
        {
            _enemy.UpperBodyAnimator.SetBool("IsWalking", false);
            _enemy.LowerBodyAnimator.SetBool("IsWalking", false);
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
        if (path.Length >= 1)
        {
            _isMoving = true;
            Vector3 currentWaypoint = path[0];

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
                if (!_isAttacking)
                {
                    transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, Time.deltaTime *_enemy.MovementSpeed);
                    Vector3 direction = transform.position - currentWaypoint;
                    //_rgb2d.velocity = Vector2.zero;
                    SetMoveState(direction.x);
                }
                yield return null;
            }
        }
    }

    void SetMoveState(float x)
    {
        if(x > 0)
        {
            _enemy.moveState = Character.MoveState.LEFT;
        }
        else if (x < 0)
        {
            _enemy.moveState = Character.MoveState.RIGHT;
        }
    }
}
