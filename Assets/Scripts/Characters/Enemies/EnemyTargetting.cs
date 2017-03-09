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

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == Tags.PLAYER)
        {
            _players.Add(coll.gameObject);
        }
    }

    void Update()
    {
        CalculateTarget();
    }

    void CalculateTarget()
    {
        for (int i = 0; i < _players.Count; i++)
        {
            float newDist = Vector2.Distance(transform.position, _players[i].transform.position);
            if(newDist < _oldDist)
            {
                _target = _players[i];
            }
            _oldDist = newDist;
        }
    }
}
