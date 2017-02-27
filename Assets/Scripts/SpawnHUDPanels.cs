using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHUDPanels : MonoBehaviour {

    [SerializeField]private GameObject _hudPanel;

	void Start () {
		
	}
	
	void Update () {
		
	}

    void SpawnPanels()
    {
        for (int i = 0; i < PlayerParty.Players.Count; i++)
        {
            Instantiate(_hudPanel);
        }
    }
}
