using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashCollider : MonoBehaviour {

    public GameObject Target;

    void OnTriggerEnter2D(Collider2D target)
    {
        Target = target.gameObject;
    }
}
