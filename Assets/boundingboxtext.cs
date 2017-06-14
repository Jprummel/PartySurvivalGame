using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class boundingboxtext : MonoBehaviour {

    SkeletonAnimation skeletonAnim;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(coll.gameObject.name);
    }
}
