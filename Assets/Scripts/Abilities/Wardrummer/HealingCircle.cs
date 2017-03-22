using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingCircle : MonoBehaviour {

    private PlayerCharacter _player;
    private HealingDrums _healingDrums;

	void Start () {
        _player = GetComponentInParent<PlayerCharacter>();
        _healingDrums = _player.GetComponent<HealingDrums>();
	}

    void OnTriggerStay2D(Collider2D other)
    {
        Character otherCharacter = other.GetComponent<Character>();

        if (this.transform.parent.tag == Tags.PLAYER && other.tag == Tags.PLAYER)
        {            
            _healingDrums.Heal(otherCharacter);
        }
        else if (this.transform.parent.tag == Tags.ENEMY && other.tag == Tags.ENEMY)
        {
            _healingDrums.Heal(otherCharacter);
        }
    }
}
