using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameData : MonoBehaviour {

	void Awake () {
        PlayerParty.Players.Clear(); //Clears the players list so there wont be duplicate characters the next round
        PlayerParty.PlayerCharacters.Clear();
        GameInformation.Wave = 1;
	}
}
