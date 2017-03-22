using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIndicators : MonoBehaviour {

    private PlayerCharacter _player;
    private Vector2 _rotation;
	// Use this for initialization
	void Start () {
        _player = GetComponentInParent<PlayerCharacter>();
	}
	
	// Update is called once per frame
	void Update () {

        if (_player.Rotated)
        {
            transform.Rotate(0, 180, 0);
            Debug.Log("Rotated");
        }
        else if (!_player.Rotated)
        {
            transform.Rotate(0, 0, 0);
            Debug.Log("Not rotated");
        }
	}
}
