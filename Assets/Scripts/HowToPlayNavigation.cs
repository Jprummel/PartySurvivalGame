using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayNavigation : MonoBehaviour {

    [SerializeField]private List<GameObject>    _howToPlayPages = new List<GameObject>();
    [SerializeField]private GameObject          _mainMenu;
                    private int                 _currentPage;

    public void NextPage()
    {
        _howToPlayPages[_currentPage].SetActive(false);
        _currentPage++;
        _howToPlayPages[_currentPage].SetActive(true);
    }

    public void PreviousPage()
    {
        _howToPlayPages[_currentPage].SetActive(false);
        _currentPage--;
        _howToPlayPages[_currentPage].SetActive(true);
    }

    public void OpenHowToPlay()
    {
        _currentPage = 0;
        _mainMenu.SetActive(false);
        for (int i = 0; i < _howToPlayPages.Count; i++)
        {
            if (_currentPage != i)
            {
                _howToPlayPages[i].SetActive(false);
            }
            else
            {
                _howToPlayPages[i].SetActive(true);
            }
        }
    }

    public void BackToMenu()
    {
        for (int i = 0; i < _howToPlayPages.Count; i++)
        {
            _howToPlayPages[i].SetActive(false);
        }
        _mainMenu.SetActive(true);
    }
}
