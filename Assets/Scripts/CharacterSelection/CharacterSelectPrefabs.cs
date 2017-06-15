using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectPrefabs : MonoBehaviour {

    [SerializeField] private List<GameObject> _characters = new List<GameObject>();
    private GameObject _selectedCharacterPrefab;
    private PlayerCharacter _selectedCharacter;

    
    public void SelectCharacter(int selectedCharacterID, int playerID)
    {
        _selectedCharacterPrefab = _characters[selectedCharacterID]; //Sets selectedcharacter prefab to the prefab in the list
        PlayerParty.Players.Add(_selectedCharacterPrefab); //Adds the prefab to the players list
        _selectedCharacter = _selectedCharacterPrefab.GetComponent<PlayerCharacter>(); //Gets the playercharacterscript from the player
        _selectedCharacter.PlayerID = playerID; //Sets selected characters id equal to the players id who selected him
        Debug.Log(playerID + " " + _selectedCharacter.PlayerID);
    }

    public void DeselectCharacter()
    {
        PlayerParty.Players.Remove(_selectedCharacterPrefab);
        PlayerParty.PlayerCharacters.Remove(_selectedCharacter);
    }
}