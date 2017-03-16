using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public static List<PlayerCharacter> deadPlayers = new List<PlayerCharacter>();

    public void RespawnPlayers()
    {
        for (int i = 0; i < deadPlayers.Count; i++)
        {
            deadPlayers[i].RestoreHealth();
            deadPlayers[i].CharacterAnimator.SetBool("IsDead", false);
            deadPlayers[i].gameObject.SetActive(true);
            Debug.Log(deadPlayers.Count);
        }
    }

    void Update()
    {
        if(WaveController.newWave != null)
        {
            RespawnPlayers();
        }
    }
}
