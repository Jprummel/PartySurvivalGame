using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerDiedWarning : MonoBehaviour {

    [SerializeField]private GameObject _warning;

    void Awake() {
        _warning = GameObject.Find("WarningText");
        StartCoroutine(Destroy());
    }

    IEnumerator WarningRoutine()
    {
        _warning.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        _warning.SetActive(false);
    }

    public void WarnPlayers(){
        StartCoroutine(WarningRoutine());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForEndOfFrame();
        if (_warning != null)
        {
            _warning.SetActive(false);
        }
    }
}
