using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldDisplay : MonoBehaviour {

    private PlayerCharacter _player;
    public PlayerCharacter Player
    {
        get { return _player; }
        set { _player = value; }
    }

    [SerializeField]private Text _playerNumber;
    [SerializeField]private Text _goldAmount;
    [SerializeField]private List<Color> _textColors = new List<Color>();
	void Start () {
        _playerNumber.text = "P" + _player.PlayerID;
        switch (_player.PlayerID)
        {
            case 1:
                _playerNumber.color = _textColors[0];
                break;
            case 2:
                _playerNumber.color = _textColors[1];
                break;
            case 3:
                _playerNumber.color = _textColors[2];
                break;
            case 4:
                _playerNumber.color = _textColors[3];
                break;
            default:
                break;
        }
	}
	
	void Update () {
        _goldAmount.text = _player.Gold.ToString("N0");
	}
}
