using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour {

    [SerializeField]protected string _name;
    [SerializeField]protected float _cost;
    protected ShopDisplay _display;

    void Start()
    {
        _display = GameObject.FindGameObjectWithTag(Tags.SHOPMANAGER).GetComponent<ShopDisplay>();
        foreach (PlayerCharacter player in PlayerParty.PlayerCharacters)
        {
            PlayerCharacter playerinfo = player.GetComponent<PlayerCharacter>();
            playerinfo.CurrentDamageCost = 500;
            playerinfo.CurrentHealthCost = 500;
            playerinfo.CurrentMoveSpeedCost = 500;
        }
    }

    public float Cost
    {
        get { return _cost; }
    }

    public string Name
    {
        get { return _name; }
    }
}
