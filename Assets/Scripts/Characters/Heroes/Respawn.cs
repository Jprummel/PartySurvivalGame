using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    [SerializeField]private EnemySpawner _enemySpawner;

    public List<PlayerCharacter> deadPlayers = new List<PlayerCharacter>();

    void RespawnPlayers()
    {
        for (int i = 0; i < deadPlayers.Count; i++)
        {
            deadPlayers[i].RestoreHealth();
            deadPlayers[i].UpperBody.state.SetAnimation(0, SpineAnimationNames.IDLE + deadPlayers[i].MoveStateName, true);
            deadPlayers[i].LowerBody.state.SetAnimation(0, SpineAnimationNames.IDLE + deadPlayers[i].moveState, true);
            deadPlayers[i].gameObject.SetActive(true);
            deadPlayers[i].CanMove = true;
            _enemySpawner._playerEnemies.Add(deadPlayers[i].gameObject);
        }
    }

    void Update()
    {
        if(WaveController.newWave != null)
        {
            RespawnPlayers();
            WaveController.newWave = null;
        }
    }
}
