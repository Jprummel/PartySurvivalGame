using System.Collections.Generic;
using UnityEngine;

public class InstantiateHuds : MonoBehaviour {

    [SerializeField]private GameObject _goldDisplay;
    [SerializeField]private GameObject _parentObject;
    [SerializeField]private List<Transform> _goldDisplayPositions = new List<Transform>();

    void Start() {
        for (int i = 0; i < PlayerParty.PlayerCharacters.Count; i++)
        {
            GameObject hud = Instantiate(_goldDisplay);
            hud.transform.SetParent(_parentObject.transform, false);
            hud.transform.position = _goldDisplayPositions[i].position;
            hud.GetComponent<GoldDisplay>().Player = PlayerParty.PlayerCharacters[i];
        }
    }
}
