using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePortraitColor : MonoBehaviour {

    private Color _defaultColor;
    private Color _inactiveColor;
    private Color _hostileColor;

	void Start () {
        _defaultColor = new Color(255, 255, 255, 1);
        _inactiveColor = new Color(0.20f, 0.20f, 0.20f, 1);
        _hostileColor = new Color();
	}

    public void SetPortraitInactive(Image portrait)
    {
        portrait.color = _inactiveColor;
    }

    public void SetPortraitActive(Image portrait)
    {
        portrait.color = _defaultColor;
    }

    public void SetPortraitHostile(Image portrait)
    {
        portrait.color = Color.red;
    }
}
