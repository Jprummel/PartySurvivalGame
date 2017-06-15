using System.Collections;
using UnityEngine;

public class PlayerDiedWarning : MonoBehaviour {

    [SerializeField]private GameObject _warning;

    IEnumerator WarningRoutine()
    {
        _warning.SetActive(true);
        yield return new WaitForSeconds(2f);
        _warning.SetActive(false);
    }

    public void WarnPlayers(){
        StartCoroutine(WarningRoutine());
    }
}
