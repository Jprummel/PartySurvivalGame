using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class boundingboxtext : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(coll.gameObject.name);
    }
}
