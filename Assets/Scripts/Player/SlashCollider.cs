﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashCollider : MonoBehaviour {

    public List<GameObject> Target = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D target)
    {
        Target.Add(target.gameObject);
        //Debug.Log(Target.Count);
    }
}