﻿using System.Collections;
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
            Debug.Log(_isMoving);
            PlayAnimation();
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
                    transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, _enemy.MovementSpeed  / 55);
                    Vector3 direction = transform.position - currentWaypoint;
                    _rgb2d.velocity = Vector2.zero;
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

    private void PlayAnimation()
    {
        if (_isMoving)
        {
            Debug.Log(_enemy.MoveStateName);
            _enemy.UpperBody.AnimationName = SpineAnimationNames.WALK + _enemy.MoveStateName;
            _enemy.LowerBody.AnimationName = SpineAnimationNames.WALK + _enemy.MoveStateName;
        }
        else if (_enemy.MoveStateName != null)
        {

            _enemy.UpperBody.AnimationName = SpineAnimationNames.IDLE + _enemy.MoveStateName;
            _enemy.LowerBody.AnimationName = SpineAnimationNames.IDLE + _enemy.MoveStateName;
        }
    }

    void MoveAnimation()
    {
            _animations.MoveAnimation();
    }
}
