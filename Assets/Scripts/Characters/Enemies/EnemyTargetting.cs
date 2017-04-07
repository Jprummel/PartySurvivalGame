using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetting : MonoBehaviour {


    private List<GameObject> _players = new List<GameObject>();

    private float _oldDist = 100;
    private GameObject _target;
    private bool _obstacle;
    private Vector3 _posRelative;
    private GameObject _lastObstacle;

    public Vector3 PosRelative
    {
        get { return _posRelative; }
    }

    public bool Obstacle
    {
        get { return _obstacle; }
        set { _obstacle = value; }
    }

    public GameObject Target
    {
        get { return _target; }
        set { _target = value; }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == Tags.OBSTACLE)
        {
            if(_lastObstacle != null && _lastObstacle.name != coll.gameObject.name)
            {
                _posRelative = transform.InverseTransformPoint(coll.gameObject.transform.position);
                _lastObstacle = coll.gameObject;
            }
            else if(_lastObstacle == null)
            {
                _lastObstacle = coll.gameObject;
            }
            //Debug.Log(_posRelative.y);
            _target = null;
            _obstacle = true;
            _oldDist = 100;
        }
    }

    void Start()
    {
        _players.AddRange(GameObject.FindGameObjectsWithTag(Tags.PLAYER));

        InvokeRepeating("CalculateTarget", 1, 0.25f);
    }

    void CalculateTarget()
    {
        for (int i = 0; i < _players.Count; i++)
        {
            if (_players[i].activeSelf)
            {
                float newDist = Vector2.Distance(transform.position, _players[i].transform.position);
                if (newDist < _oldDist)
                {
                    _target = _players[i];
                }
                _oldDist = newDist;
            }
        }
    }
}
