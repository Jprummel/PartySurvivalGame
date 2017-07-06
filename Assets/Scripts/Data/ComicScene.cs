using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComicScene : MonoBehaviour {

    [SerializeField]private string _levelToLoad;
    [SerializeField]private List<GameObject> _continueObjects = new List<GameObject>();
    [SerializeField]private List<Image> _comicPanels = new List<Image>();
    private Fader _fader;
    private SceneLoader _sceneLoader;
    private int _currentPanel = 0;
    private bool _isLoading;

	void Start () {
        _fader = GameObject.FindGameObjectWithTag(Tags.FADEPANEL).GetComponent<Fader>();
        _sceneLoader = GameObject.FindGameObjectWithTag(Tags.SCENELOADER).GetComponent<SceneLoader>();
        _fader.Fade(1,1.5f,_comicPanels[_currentPanel]);
        _currentPanel++;
	}
	
	void Update () {
        FadePanel();
	}

    void FadePanel()
    {
        if (Input.GetButtonDown(InputAxes.MENU_NAV_CONFIRM)) //If the A button is pressed on any controller
        {
            if (_currentPanel < _comicPanels.Count) //If this isnt the last panel
            {   //Fade in comic panel and ready the next one
                _fader.Fade(1,3,_comicPanels[_currentPanel]);
                _currentPanel++;
            }
            else if (_currentPanel == _comicPanels.Count && !_isLoading) //If this is the last panel
            {   //Load corresponding level
                for (int i = 0; i < _continueObjects.Count; i++)
                {
                    _continueObjects[i].SetActive(false);
                }
                _sceneLoader.ChangeScene(_levelToLoad);
                _isLoading = true;
            }
        }
    }
}
