using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectUI : MonoBehaviour {

    [SerializeField]private List<GameObject> _selectionPortraits = new List<GameObject>();
    [SerializeField]private List<GameObject> _selectionNames = new List<GameObject>();
    [SerializeField]private GameObject _joinGameImage;
    [SerializeField]private GameObject _readyText;

    private int _selectedCharacterNumber;

    public int SelectedCharacterNumber
    {
        get { return _selectedCharacterNumber; }
        set { _selectedCharacterNumber = value; }
    }

    public List<GameObject> SelectionPortraits
    {
        get { return _selectionPortraits; }
    }

    public List<GameObject> SelectionNames
    {
        get { return _selectionNames; }
    }

	void Start () {
        for (int i = 0; i < _selectionPortraits.Count; i++)
        {
            //Deactivate all portaits and nameplates at the start
            _selectionPortraits[i].SetActive(false);
            _selectionNames[i].SetActive(false);
        }
	}

    public void ToggleJoinGameImage(bool isActive)
    {
        _joinGameImage.SetActive(isActive);
    }

    public void SelectedCharacterVisuals()
    {
        for (int i = 0; i < _selectionPortraits.Count; i++)
        {
            if (i == _selectedCharacterNumber) //If i is equal to _selectedCharacterNumber activate the fitting name and portrait
            {
                _selectionPortraits[i].SetActive(true);
                _selectionNames[i].SetActive(true);
            }else //If it is not equal, de-activate it
            {
                _selectionPortraits[i].SetActive(false);
                _selectionNames[i].SetActive(false);
            }
        }
    }

    public void DisablePortraitsAndNames()
    {
        for (int i = 0; i < _selectionPortraits.Count; i++)
        {
            _selectionPortraits[i].SetActive(false);
            _selectionNames[i].SetActive(false);
        }
    }
}