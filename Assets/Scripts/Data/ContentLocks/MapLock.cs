using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLock : MonoBehaviour {

    [SerializeField]private List<Button> _mapSelectButtons = new List<Button>();
    [SerializeField]private List<GameObject> _requirementPanels = new List<GameObject>();

	void Start () {
        CheckForUnlockedMaps();		
	}

    void CheckForUnlockedMaps()
    {
        //If a map is not unlocked, deactivate the button and show a panel that shows the unlock requirements
        //else, remove the panel and activate the button
        if (!LockData.ExecutionersRoadUnlocked)
        {
            _mapSelectButtons[0].interactable = false;
            _requirementPanels[0].SetActive(true);
        }
        else
        {
            _mapSelectButtons[0].interactable = true;
            _requirementPanels[0].SetActive(false);
        }

        if (!LockData.DungeonsUnlocked)
        {
            _mapSelectButtons[1].interactable = false;
            _requirementPanels[1].SetActive(true);
        }
        else
        {
            _mapSelectButtons[1].interactable = true;
            _requirementPanels[1].SetActive(false);
        }

        if (!LockData.ThroneRoomUnlocked)
        {
            _mapSelectButtons[2].interactable = false;
            _requirementPanels[2].SetActive(true);
        }
        else
        {
            _mapSelectButtons[2].interactable = true;
            _requirementPanels[2].SetActive(false);
        }
    }
}
