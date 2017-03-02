using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayShopTimer : MonoBehaviour {

    [SerializeField]private Text _timerText;
    [SerializeField]private ShopDisplay _display;

	void Update () {
        DisplayTimeLeft();
	}

    void DisplayTimeLeft()
    {
        _timerText.text = Mathf.Round(_display.TimeToShop).ToString();
    }
}
