using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetting : MonoBehaviour {


    private List<GameObject> _players = new List<GameObject>();

    private float _oldDist = 250;
    private GameObject _target;
    private Unit _AStar;

    public GameObject Target
    {
        get { return _target; }
        set { _target = value; }
    }  

    void Start()
    {
        _AStar = GetComponent<Unit>();
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
        _AStar.target = _target.transform;
    }
}
