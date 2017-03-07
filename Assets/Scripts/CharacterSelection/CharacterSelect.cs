using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour {

    [SerializeField]private int _playerID;

    public void SelectCharacter(GameObject character)
    {
        PlayerParty.Players.Add(character);
        PlayerCharacter playerCharacter = character.GetComponent<PlayerCharacter>();
        PlayerParty.PlayerCharacters.Add(playerCharacter);
        playerCharacter.PlayerID = _playerID;
    }
}
