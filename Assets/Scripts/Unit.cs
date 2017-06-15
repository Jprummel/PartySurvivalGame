using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour {

    private CharacterAnimations _animations;
    private bool _isMoving = false;
    private Enemy _enemy;
    private Rigidbody2D _rgb2d;
    public Transform target;
    Vector3[] path;
    int targetIndex;

    void Start()
    {
        _enemy = GetComponent<Enemy>();
        _rgb2d = GetComponent<Rigidbody2D>();
        _animations = GetComponent<CharacterAnimations>();
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
        if (path.Length >= 1)
        {
            _isMoving = true;
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
                    /*float dirX = currentWaypoint.x - transform.position.x;
                    float dirY = currentWaypoint.y - transform.position.y;*/
                    Vector3 direction = transform.position - currentWaypoint;
                    var localDir = transform.InverseTransformDirection(direction);
                    Debug.Log(localDir);
                    _rgb2d.velocity = Vector2.zero;
                    SetMoveState(localDir.x, localDir.y);
                }else if(distance < _enemy.AttackRange)
                {
                    _isMoving = false;
                }
                MoveAnimation();
                yield return null;
            }
        }
    }

    void SetMoveState(float x, float y)
    {
        if (x < 0 && x < y)
        {
            _enemy.moveState = Character.MoveState.RIGHT;
        }
        if (x > 0 && x > y)
       {
            _enemy.moveState = Character.MoveState.LEFT;
        }
       if (y < 0 && y > x)
       {
            _enemy.moveState = Character.MoveState.DOWN;
       }
       if(y > 0 && y > x)
       {
            _enemy.moveState = Character.MoveState.FRONT;
       }
    }

    void MoveAnimation()
    {
        if (_isMoving && _enemy.MoveStateName != null)
        {
            _animations.MoveAnimation();
        }
        /*else
        {
            _animations.IdleAnimation();
        }*/
    }
}
