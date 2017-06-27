using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptCollector : MonoBehaviour {

    private PlayerCharacter     _player;
    private PlayerAttack        _playerAttack;
    private Ability             _ability;
    private Charge              _charge;
    private ArrowRain           _arrowRain;
    private Whirlwind           _whirlwind;
    private PlayerMovement      _playerMovement;
    private ControllerInput     _input;

    public PlayerCharacter  Player          { get { return _player; } }
    public PlayerAttack     PlayerAttack    { get { return _playerAttack; } }
    public Charge           Charge          { get { return _charge; } }
    public ArrowRain        ArrowRain       { get { return _arrowRain; } }
    public Whirlwind        Whirlwind       { get { return _whirlwind; } } 
    public PlayerMovement   PlayerMovement  { get { return _playerMovement; } }
    public ControllerInput  Input           { get { return _input; } }
    
	void Awake () {
        _player         = GetComponent<PlayerCharacter>();
        _playerAttack   = GetComponent<PlayerAttack>();
        _playerMovement = GetComponent<PlayerMovement>();
        _input          = GetComponent<ControllerInput>();

        switch (Player.Name)
        {
            case "Knight":
                _charge = GetComponent<Charge>();
                _arrowRain = null;
                _whirlwind = null;
                break;
            case "Commander":
                _charge = null;
                _arrowRain = GetComponent<ArrowRain>();
                _whirlwind = null;
                break;
            case "Warrior":
                _charge = null;
                _arrowRain = null;
                _whirlwind = GetComponent<Whirlwind>();
                break;
        }
	}

}
