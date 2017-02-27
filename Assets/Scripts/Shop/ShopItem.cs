using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour {

    [SerializeField]protected string _name;
    [SerializeField]protected float _cost;
    protected ShopDisplay _display;

    void Start()
    {
        _display = GetComponentInParent<ShopDisplay>();
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
