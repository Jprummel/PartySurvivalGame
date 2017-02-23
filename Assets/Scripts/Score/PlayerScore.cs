using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    void AddScore(PlayerCharacter player,int scoreToAdd)
    {
        player.Score += scoreToAdd;
    }

    void ReduceScore(PlayerCharacter player, int scoreToReduce)
    {
        player.Score -= scoreToReduce;
    }
}
