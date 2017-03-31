using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePortraitColor : MonoBehaviour {

	void Start () {

    }

    public void SetPortraitHostile(Image portrait)
    {
        portrait.color = Color.red;
    }
}
