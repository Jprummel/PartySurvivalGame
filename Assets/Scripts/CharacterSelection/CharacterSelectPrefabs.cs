using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectPrefabs : MonoBehaviour {

    [SerializeField] private List<GameObject> _characters = new List<GameObject>();
    private GameObject _selectedCharacterPrefab;
    private PlayerCharacter _selectedCharacter;
    private int _currentPlayerID;

    
    public void SelectCharacter(int selectedCharacterID, int playerID)
    {
        _selectedCharacterPrefab = _characters[selectedCharacterID]; //Sets selectedcharacter prefab to the prefab in the list
        PlayerParty.Players.Add(_selectedCharacterPrefab); //Adds the prefab to the players list
        _currentPlayerID = playerID;
        PlayerParty.PlayerIDs.Add(playerID);//Adds the player id to player id list
    }

    public void DeselectCharacter(int playerID)
    {
        PlayerParty.Players.Remove(_selectedCharacterPrefab);
        PlayerParty.PlayerCharacters.Remove(_selectedCharacter);
        if (PlayerParty.PlayerIDs.Contains(playerID))
        {
            PlayerParty.PlayerIDs.Remove(playerID);
        }
    }
}