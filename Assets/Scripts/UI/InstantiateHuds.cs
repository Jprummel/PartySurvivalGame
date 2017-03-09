using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateHuds : MonoBehaviour {

    [SerializeField]private GameObject _hud;
    [SerializeField]private List<Transform> _hudPositions = new List<Transform>();

    void Awake () {
        for (int i = 0; i < PlayerParty.Players.Count; i++)
        {
            Debug.Log("ay");
            GameObject hud = Instantiate(_hud);
            hud.transform.position = _hudPositions[i].position;
        }
    }
}
