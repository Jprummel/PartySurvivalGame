using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMap : MonoBehaviour {

    [SerializeField]private string _comicToLoad;
    private MapSelection _mapSelection;

    private void Awake()
    {
        _mapSelection = GameObject.FindGameObjectWithTag(Tags.MAPSELECTION).GetComponent<MapSelection>();
    }

    public void ChooseMap()
    {
        _mapSelection.SelectedMap = _comicToLoad;
    }
}
