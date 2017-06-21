using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMap : MonoBehaviour {

    [SerializeField]private string _comicToLoad;
    [SerializeField]private string _levelToLoad;
    private MapSelection _mapSelection;

    private void Awake()
    {
        _mapSelection = GameObject.FindGameObjectWithTag(Tags.MAPSELECTION).GetComponent<MapSelection>();
    }

    public void ChooseMap()
    {
        if (!SettingsInformation.SkipCutscenes)
        {
            _mapSelection.SelectedMap = _comicToLoad;
        }
        else
        {
            _mapSelection.SelectedMap = _levelToLoad;
        }
    }
}
