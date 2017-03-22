using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetting : MonoBehaviour {


    private List<GameObject> _players = new List<GameObject>();

    private float _oldDist = 420;
    private GameObject _target;
    public GameObject Target
    {
        get{ return _target; }
        set{ _target = value; }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if(coll.gameObject.tag == Tags.OBSTACLE)
        {
            _target = null;
            _oldDist = 420;
        }
    }

    void Start()
    {
        _players.AddRange(GameObject.FindGameObjectsWithTag(Tags.PLAYER));

        InvokeRepeating("CalculateTarget", 1, 0.33f);
    }

    void CheckForObstacles()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 2f);
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 1f, Vector2.zero);
        if (hit.collider != null)
        {
<<<<<<< HEAD
            if (hit.collider.tag == Tags.OBSTACLE)
            {
                _target = null;
            }
        }
        else
        {
            _oldDist = 420;
            CalculateTarget();
=======
            //Debug.Log(hit.collider.gameObject.name);
>>>>>>> origin/master
        }
    }

    void Update()
    {
        //CheckForObstacles();
    }

    void CalculateTarget()
    {
        for (int i = 0; i < _players.Count; i++)
        {
            //if (_players[i].activeSelf)
            //{
                float newDist = Vector2.Distance(transform.position, _players[i].transform.position);
                if (newDist < _oldDist)
                {
                    _target = _players[i];
                }
                _oldDist = newDist;
            //}
        }
    }
}
