using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

    private ShopDisplay         _shopDisplay;
    private GameObject          _pauseGameObject;
    private WalkParticle        _walkParticle;
    private CharacterSoundFX    _soundEffects;
    private WaveController      _waveController;
    private PauseGame           _pauseGame;
    private PlayerCharacter     _player;
    private PlayerMovement      _playerMovement;
    private PlayerAttack        _playerAttack;

    void Awake()
    {
        _shopDisplay    = GameObject.FindGameObjectWithTag(Tags.SHOPMANAGER).GetComponent<ShopDisplay>();
        _pauseGameObject = GameObject.FindGameObjectWithTag(Tags.PAUSEOBJECT);
        _walkParticle   = GetComponentInChildren<WalkParticle>();
        _soundEffects   = GetComponent<CharacterSoundFX>();
        _waveController = GameObject.FindGameObjectWithTag(Tags.WAVEMANAGER).GetComponent<WaveController>();
        _pauseGame      = _pauseGameObject.GetComponent<PauseGame>();
        _player         = GetComponent<PlayerCharacter>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAttack   = GetComponent<PlayerAttack>();
    }

    void Update()
    {
        ControllerInputs();
    }

    void ControllerInputs()
    {
        if (_waveController.IsCombatPhase && !_pauseGame.GameIsPaused && _player.CanMove)
        {
            if (Input.GetButtonDown(InputAxes.XBOX_A + _player.PlayerID))
            {
                //Ability 1
                //_soundEffects.PlaySFX();
            }

            if (Input.GetButtonDown(InputAxes.XBOX_B + _player.PlayerID))
            {
                //Ability 2
                //_soundEffects.PlaySFX();
            }

            if (Input.GetButtonDown(InputAxes.XBOX_X + _player.PlayerID) && _playerAttack.ReadyToAttack)
            {
                _playerAttack.Attack();
                _soundEffects.PlayLightAttackAudio(); //Basic Attack (miss) sound
            }

            if (Input.GetButtonDown(InputAxes.XBOX_Y + _player.PlayerID) && _playerAttack.ReadyToAttack)
            {
                //Heavy Attack
                _soundEffects.PlayHeavyAttackAudio(); // Heavy Attack (miss) sound
                _playerAttack.HeavyAttack();
            }

            if (Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _player.PlayerID) != 0 || Input.GetAxis(InputAxes.LEFT_JOYSTICK_Y + _player.PlayerID) != 0)
            {
                float x = Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _player.PlayerID);
                float y = Input.GetAxis(InputAxes.LEFT_JOYSTICK_Y + _player.PlayerID);
                Vector2 moveDir = new Vector2(x, y);
                _playerMovement.Move(moveDir.normalized);
                _soundEffects.PlayWalkAudio();
                _walkParticle.ShowParticle();
            }
            else
            {
                _playerMovement.Move(new Vector2(0, 0));
                _walkParticle.DisableParticle();
                _soundEffects.StopWalkSound();
            }            
        }
        
        if (Input.GetButtonDown(InputAxes.START + _player.PlayerID))
        {
            _pauseGame.TogglePause();
        }

        if (!_waveController.IsCombatPhase)
        {
            if (Input.GetButtonDown(InputAxes.XBOX_B + _player.PlayerID) && _shopDisplay.MatchingPlayer == _player)
            {
                _shopDisplay.NextPlayerShopTurn();
            }

            _soundEffects.StopWalkSound();
            _walkParticle.DisableParticle();
            _playerMovement.Move(new Vector2(0,0));
        }

    }
}
