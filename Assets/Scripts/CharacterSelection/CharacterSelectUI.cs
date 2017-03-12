using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectUI : MonoBehaviour {

    [SerializeField]private List<GameObject> _selectionPortraits = new List<GameObject>();
    [SerializeField]private List<GameObject> _selectionNames = new List<GameObject>();
    [SerializeField]private GameObject _joingGameImage;
    [SerializeField]private GameObject _readyText;
    private CharacterSelect _characterSelect;

    public List<GameObject> SelectionPortraits
    {
        get { return _selectionPortraits; }
    }

    public List<GameObject> SelectionNames
    {
        get { return _selectionNames; }
    }

	void Start () {
        _characterSelect = GetComponent<CharacterSelect>();
        for (int i = 0; i < _selectionPortraits.Count; i++)
        {
            //Deactivate all portaits and nameplates at the start
            _selectionPortraits[i].SetActive(false);
            _selectionNames[i].SetActive(false);
        }
	}

    public void SelectedCharacterVisuals()
    {
        for (int i = 0; i < _selectionPortraits.Count; i++)
        {
            if (i == _characterSelect.SelectedCharacterNumber) //If i is equal to _selectedCharacterNumber activate the fitting name and portrait
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
