using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDisplay : MonoBehaviour {

    private int _shopPanelID;
    public int ShopPanelID
    {
        get { return _shopPanelID;}
        set { _shopPanelID = value; }
    }

    private PlayerCharacter _matchingPlayer;
    public PlayerCharacter MatchingPlayer
    {
        get { return _matchingPlayer; }
        set { _matchingPlayer = value; }
    }

	void Start () {
        FindingNemo();// ><> blub
    }
	
    void FindingNemo()
    {
        for (int i = 0; i < PlayerParty.PlayerCharacters.Count; i++)
        {
            if (PlayerParty.PlayerCharacters[i].PlayerID == _shopPanelID)
            {
                _matchingPlayer = PlayerParty.PlayerCharacters[i];
            }
        }
    }
}
