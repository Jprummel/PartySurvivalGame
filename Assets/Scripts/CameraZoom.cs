using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraZoom : MonoBehaviour {

    [SerializeField]private float _maxSize;
    [SerializeField]private float _minSize;
    [SerializeField]private float _maxZoom;
    [SerializeField]private float _minZoom;
    private int _playersFarAway;

	void Update () {
        CameraLerp();
	}

    /*void CheckForPlayerPositions()
    {
        float distance = Vector3.Distance(PlayerParty.PlayerCharacters[i].transform.position, Camera.main.transform.position);

        if (distance < 10)
        {
            
        }
        else if (distance >= 10 && Camera.main.orthographicSize <= _maxSize)
        {
            Camera.main.orthographicSize += Mathf.Lerp(_minZoom, _maxZoom, Time.deltaTime);
            if (Camera.main.orthographicSize > _maxSize)
            {
                Camera.main.orthographicSize = _maxSize;
            }
        }
    }*/

    void CameraLerp()
    {
        for (int i = 0; i < PlayerParty.PlayerCharacters.Count; i++)
        {
            float distance = Vector3.Distance(PlayerParty.PlayerCharacters[i].transform.position, Camera.main.transform.position);
            
            if (distance < 10 && Camera.main.orthographicSize > _minSize)
            {

                Camera.main.orthographicSize += Mathf.Lerp(-_minZoom, -_maxZoom, Time.deltaTime);
                if (Camera.main.orthographicSize < _minSize)
                {
                    Camera.main.orthographicSize = _minSize;
                }
            }
            else if (distance >= 10 && Camera.main.orthographicSize <= _maxSize)
            {
                Camera.main.orthographicSize += Mathf.Lerp(_minZoom, _maxZoom, Time.deltaTime);
                if (Camera.main.orthographicSize > _maxSize)
                {
                    Camera.main.orthographicSize = _maxSize;
                }
            }
        }
    }
}
