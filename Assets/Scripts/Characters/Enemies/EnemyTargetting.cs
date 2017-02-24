using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetting : MonoBehaviour {

    private List<GameObject> _players;
    [HideInInspector]public Vector2 closestTarget;

	// Use this for initialization
	void Start () {
        _players = PlayerParty.Players;
	}

	void Update () {
        CalculateDist();
	}

    void CalculateDist()
    {
        float ClosestDistance = 420;

        for (int i = 0; i < _players.Count; i++)
        {
            float DistToPlayer = Vector2.Distance(transform.position, _players[i].transform.position);
            if(DistToPlayer < ClosestDistance)
            {
                ClosestDistance = DistToPlayer;
                closestTarget = _players[i].transform.position;
            }
        }       
    }

}
