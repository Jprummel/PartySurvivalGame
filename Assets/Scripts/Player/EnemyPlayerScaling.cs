using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerScaling : MonoBehaviour {

    private Respawn _respawn;

	void Awake () {
        _respawn = GameObject.FindGameObjectWithTag(Tags.PLAYERPARTY).GetComponent<Respawn>();
	}

    public void Scale()
    {
        for (int i = 0; i < _respawn.deadPlayers.Count; i++)
        {
            _respawn.deadPlayers[i].Damage = _respawn.deadPlayers[i].Damage * _respawn.deadPlayers[i].DamageScaleFactor;
            _respawn.deadPlayers[i].MaxHealth = _respawn.deadPlayers[i].MaxHealth * _respawn.deadPlayers[i].HealthScaleFactor;
        }
    }
}
