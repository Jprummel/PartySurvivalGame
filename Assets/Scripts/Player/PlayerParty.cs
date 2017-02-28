using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParty : MonoBehaviour {

    [SerializeField]public static List<GameObject>      Players             = new List<GameObject>();
    [SerializeField]public static List<PlayerCharacter> PlayerCharacters    = new List<PlayerCharacter>();
    public static List<GameObject>                      ShopPanels          = new List<GameObject>();
    public static List<ShopDisplay>                     ShopDisplays        = new List<ShopDisplay>();
	// Use this for initialization
	void Start () {
        AddPlayers();
        AddCharacters();
        AddShopPanels();
        AddShopDisplays();
	}

    void AddPlayers()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag(Tags.PLAYER))
        {
            Players.Add(player);
        }
    }

    void AddCharacters()
    {
        for (int i = 0; i < Players.Count; i++)
        {
            PlayerCharacter characterToAdd = Players[i].GetComponent<PlayerCharacter>();
            PlayerCharacters.Add(characterToAdd);                       
        }
    }

    void AddShopPanels()
    {
        foreach (GameObject shopPanel in GameObject.FindGameObjectsWithTag(Tags.SHOPPANEL))
        {
            ShopPanels.Add(shopPanel);
        }
    }

    void AddShopDisplays()
    {
        for (int i = 0; i < ShopPanels.Count; i++)
        {
            ShopDisplay displayToAdd = ShopPanels[i].GetComponent<ShopDisplay>();
            ShopDisplays.Add(displayToAdd);
        }
    }
}
