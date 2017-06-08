using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapSelection : MonoBehaviour {

    [SerializeField]private SelectionScreen _selectionScreen;
    [SerializeField]private CharacterSelect _characterSelect;
    [SerializeField]private GameObject _characterSelectionScreen;
    [SerializeField]private GameObject _mapSelectionScreen;
    [SerializeField]private GameObject _returnToMenuScreen;
    [SerializeField]private EventSystem _returnScreenEventSystem;
    [SerializeField]private GameObject _eventSystem;
    [SerializeField]private GameObject _returnButton;
    private SceneLoader _sceneLoader;

    private string _selectedMap;
    public string SelectedMap
    {
        get { return _selectedMap; }
        set { _selectedMap = value; }
    }

    void Start()
    {
        _sceneLoader = GameObject.FindGameObjectWithTag(Tags.SCENELOADER).GetComponent<SceneLoader>();
    }

    void Update()
    {
        EnableReturnToMenuScreen();
    }

    public void SelectMap(string levelToLoad)
    {
        _selectedMap = levelToLoad;
        StartCoroutine(_selectionScreen.SwitchToCharacterSelect());
        _eventSystem.SetActive(false);
    }

    void EnableReturnToMenuScreen()
    {
        if (!_characterSelect.CharacterSelectState)
        {
            if (Input.GetButtonDown(InputAxes.XBOX_B + "1"))
            {
                _eventSystem.SetActive(false);
                _returnToMenuScreen.SetActive(true);
            }
        }
    }

    public void ReturnToMenu()
    {
        _sceneLoader.ChangeScene("MainMenu");
    }

    public void Cancel()
    {
        _returnScreenEventSystem.SetSelectedGameObject(_returnButton);
        _returnToMenuScreen.SetActive(false);
        _eventSystem.SetActive(true);
    }
}
