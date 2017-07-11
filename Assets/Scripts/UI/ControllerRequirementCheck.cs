using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRequirementCheck : MonoBehaviour {
    
    private SceneLoader _sceneLoader;

    void Start ()
    {
        _sceneLoader = GameObject.FindGameObjectWithTag(Tags.SCENELOADER).GetComponent<SceneLoader>();
    }
	
	void Update ()
    {
        if (Input.GetButtonDown(InputAxes.MENU_NAV_CONFIRM))
        {
            _sceneLoader.ChangeScene("MainMenu");
        }
	}
}
