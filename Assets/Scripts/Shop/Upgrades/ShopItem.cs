using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour {

    [SerializeField]protected string _name;
    [SerializeField]protected float _cost;
    protected bool _maxedOut;
    protected ShopDisplay _display;

    void Start()
    {
        _display = GameObject.FindGameObjectWithTag(Tags.SHOPMANAGER).GetComponent<ShopDisplay>();
    }

    public float Cost
    {
        get { return _cost; }
    }

    public string Name
    {
        get { return _name; }
    }

    public bool MaxedOut
    {
        get { return _maxedOut; }
    }
}
