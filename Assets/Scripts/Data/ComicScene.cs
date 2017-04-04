using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComicScene : MonoBehaviour {

    [SerializeField]private string _levelToLoad;
    [SerializeField]private List<Image> _comicPanels = new List<Image>();
    private Fades _fades;
    private SceneLoader _sceneLoader;
    private int _currentPanel = 0;

	void Start () {
        _fades = GameObject.FindGameObjectWithTag(Tags.FADEROBJECT).GetComponent<Fades>();
        _sceneLoader = GameObject.FindGameObjectWithTag(Tags.SCENELOADER).GetComponent<SceneLoader>();
        StartCoroutine(_fades.FadeOut(_comicPanels[_currentPanel],false,1.5f));
        _currentPanel++;
	}
	
	void Update () {
        FadePanel();
	}

    void FadePanel()
    {
        if (Input.GetButtonDown(InputAxes.XBOX_A + "1"))
        {
            if (_currentPanel < _comicPanels.Count)
            {
                StartCoroutine(_fades.FadeOut(_comicPanels[_currentPanel],false,1.5f));
                _currentPanel++;
            }
            else if (_currentPanel == _comicPanels.Count)
            {
                _sceneLoader.ChangeScene(_levelToLoad);
            }
        }
    }
}
