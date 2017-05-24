using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour {

    [SerializeField]protected string _name;
    [SerializeField]protected float _cost;
    [SerializeField]protected GameObject _particle;
    protected ShopSoundFX _soundEffects;
    protected bool _maxedOut;
    protected ShopDisplay _display;

    void Start()
    {
        _soundEffects = GameObject.FindGameObjectWithTag(Tags.SHOPMANAGER).GetComponent<ShopSoundFX>();
        _display = GameObject.FindGameObjectWithTag(Tags.SHOPMANAGER).GetComponent<ShopDisplay>();
    }

    protected void SpawnParticle()
    {
        GameObject particle = Instantiate(_particle, this.transform);
        particle.transform.position = this.transform.position;
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
