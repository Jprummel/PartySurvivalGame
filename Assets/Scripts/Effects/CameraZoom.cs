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
    private List<GameObject> _playersInRange = new List<GameObject>();
    private PlayerParty _playerParty;

    void Start()
    {
        _playerParty = GameObject.FindGameObjectWithTag(Tags.PLAYERPARTY).GetComponent<PlayerParty>();
    }

	void Update () {
        CameraRangeCheck();
        CameraLerp();
	}

    void CameraRangeCheck()
    {
        for (int i = 0; i < _playerParty.InGamePlayers.Count; i++)
        {
            float distance = Vector3.Distance(_playerParty.InGamePlayers[i].transform.position, Camera.main.transform.position);

            if (distance < 10 && !_playersInRange.Contains(_playerParty.InGamePlayers[i]))
            {
                _playersInRange.Add(_playerParty.InGamePlayers[i]);
            }
            else if (distance >= 10)
            {
                _playersInRange.Remove(_playerParty.InGamePlayers[i]);
            }
        }
    }

    void CameraLerp()
    {
        //If the players in range equal the amount of players in game have the camera zoomed in on the screen
        //If the amount of players in range is less then the amount of players in game, zoom out until max zoom is reached
        if (_playersInRange.Count >= _playerParty.InGamePlayers.Count && Camera.main.orthographicSize > _minSize)
        {//Zoom in
            Camera.main.orthographicSize += Mathf.Lerp(-_minZoom, -_maxZoom, Time.deltaTime);
            if (Camera.main.orthographicSize < _minSize)
            {
                Camera.main.orthographicSize = _minSize;
            }
        }
        else if (_playersInRange.Count < _playerParty.InGamePlayers.Count && Camera.main.orthographicSize <= _maxSize)
        { //Zoom out
            Camera.main.orthographicSize += Mathf.Lerp(_minZoom, _maxZoom, Time.deltaTime);
            if (Camera.main.orthographicSize > _maxSize)
            {
                Camera.main.orthographicSize = _maxSize;
            }
        }
    }
}
