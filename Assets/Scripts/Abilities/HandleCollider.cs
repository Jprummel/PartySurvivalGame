using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandleCollider : MonoBehaviour, IEventSystemHandler {

    private CapsuleCollider2D _collider;

	void Start () {
        _collider = GetComponent<CapsuleCollider2D>();
	}
	
    public void SwitchCollider(bool _colliderStatus)
    {
        _collider.enabled = _colliderStatus;
    }
}
