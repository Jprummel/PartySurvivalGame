using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShopHUDPanels : MonoBehaviour {

    [SerializeField]private GameObject _hudPanel;
    [SerializeField]private Transform _panelParent;

	void Start () {
        SpawnPanels();
	}

    void SpawnPanels()
    {
        for (int i = 0; i < PlayerParty.Players.Count; i++)
        {
            GameObject panel = Instantiate(_hudPanel);
            ShopDisplay display = panel.GetComponent<ShopDisplay>();
            RectTransform panelTransform = panel.GetComponent<RectTransform>();
            display.ShopPanelID = i + 1;
            switch (display.ShopPanelID)
            {
                case 1:
                    panelTransform.anchoredPosition = new Vector2(0, Screen.height / 2);
                    panelTransform.sizeDelta = new Vector2(Screen.width / 2, Screen.height / 2);
                    break;
                case 2:
                    panelTransform.anchoredPosition = new Vector2(Screen.width / 2, Screen.height / 2);
                    panelTransform.sizeDelta = new Vector2(Screen.width / 2, Screen.height / 2);
                    break;
                case 3:
                    panelTransform.anchoredPosition = new Vector2(0,0);
                    panelTransform.sizeDelta = new Vector2(Screen.width / 2, Screen.height / 2);
                    break;
                case 4:
                    panelTransform.anchoredPosition = new Vector2(Screen.width / 2, 0);
                    panelTransform.sizeDelta = new Vector2(Screen.width / 2, Screen.height / 2);
                    break;
            }
            //panel.SetActive(false);
            panel.transform.SetParent(_panelParent);
        }
    }
}
