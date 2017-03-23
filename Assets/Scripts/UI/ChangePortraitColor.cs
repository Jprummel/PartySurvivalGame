using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePortraitColor : MonoBehaviour {

    private Color _hostileColor;

	void Start () {
        _hostileColor = new Color(255,109,56,1);
	}

    public void SetPortraitHostile(Image portrait)
    {
        portrait.color = Color.red;
    }
}
