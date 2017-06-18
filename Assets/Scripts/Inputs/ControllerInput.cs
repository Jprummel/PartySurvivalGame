﻿using UnityEngine;

public class ControllerInput : MonoBehaviour {

    private CharacterAnimations    _animations;
    private ShopDisplay         _shopDisplay;
    private WalkParticle        _walkParticle;
    private CharacterSoundFX    _soundEffects;
    private WaveController      _waveController;
    private PauseGame           _pauseGame;
    private PlayerCharacter     _player;
    private PlayerMovement      _playerMovement;
    private PlayerAttack        _playerAttack;

    void Awake()
    {
        _shopDisplay        = GameObject.FindGameObjectWithTag(Tags.SHOPMANAGER).GetComponent<ShopDisplay>();
        _pauseGame          = GameObject.FindGameObjectWithTag(Tags.PAUSEOBJECT).GetComponent<PauseGame>();
        _walkParticle       = GetComponentInChildren<WalkParticle>();
        _soundEffects       = GetComponent<CharacterSoundFX>();
        _waveController     = GameObject.FindGameObjectWithTag(Tags.WAVEMANAGER).GetComponent<WaveController>();
        _player             = GetComponent<PlayerCharacter>();
        _playerMovement     = GetComponent<PlayerMovement>();
        _playerAttack       = GetComponent<PlayerAttack>();
    }

    void Update()
    {
        ControllerInputs();
    }

    void ControllerInputs()
    {
        if (_waveController.IsCombatPhase && !_pauseGame.GameIsPaused && !_player.IsDead)
        {
            if (_player.Ability != null)
            {
                if (Input.GetButtonDown(InputAxes.XBOX_A + _player.PlayerID))
                {
                    _player.Ability.UseAbility();
                    //_animations.AbilityAnimation();
                }

                if (Input.GetButtonDown(InputAxes.XBOX_B + _player.PlayerID) && _player.Ability.UsingAbility)
                {
                    if (_player.Ability.UsingAbility)
                    {
                        _player.Ability.CancelAbility();
                    }
                }
            }

            if (Input.GetButtonDown(InputAxes.XBOX_X + _player.PlayerID) && _playerAttack.ReadyToAttack)
            {
                _playerAttack.Attack();
                _player.Animations.PlayerAttackAnimation(_player.LightAttackState);
                _soundEffects.PlayLightAttackAudio(); //Basic Attack (miss) sound
            }

            if (Input.GetButtonDown(InputAxes.XBOX_Y + _player.PlayerID) && _playerAttack.ReadyToAttack)
            {
                //Heavy Attack
                _soundEffects.PlayHeavyAttackAudio(); // Heavy Attack (miss) sound
                _playerAttack.HeavyAttack();
                _player.Animations.PlayerAttackAnimation(3);
            }
            if (_player.CanMove)
            {
                if (Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _player.PlayerID) != 0 || Input.GetAxis(InputAxes.LEFT_JOYSTICK_Y + _player.PlayerID) != 0)
                {
                    float x = Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _player.PlayerID);
                    float y = Input.GetAxis(InputAxes.LEFT_JOYSTICK_Y + _player.PlayerID);
                    Vector2 moveDir = new Vector2(x, y);
                    _playerMovement.Move(moveDir.normalized);
                    SetMoveState(x, y);
                    _soundEffects.PlayWalkAudio();
                    if (x != 0)
                    {
                       // _walkParticle.ShowParticle(); // only show particle when player isnt running straight up or down
                    }
                }
                else
                {
                    _playerMovement.Move(new Vector2(0, 0));
                    //_walkParticle.DisableParticle();
                    _soundEffects.StopWalkSound();
                }
            }
            else if (!_player.CanMove)
            {
                _player.Animations.IdleAnimation();
                //_player.LowerBody.AnimationName = SpineAnimationNames.IDLE + _player.MoveStateName;
            }
        }
        
        if (Input.GetButtonDown(InputAxes.START + _player.PlayerID) && _waveController.IsCombatPhase)
        {
            _pauseGame.TogglePause();
        }

        if (!_waveController.IsCombatPhase)
        {
            if (Input.GetButtonDown(InputAxes.XBOX_B + _player.PlayerID) && _shopDisplay.MatchingPlayer == _player && _shopDisplay.ShopIsOpen) //If player presses B while its his turn and the shop is open
            {
                _shopDisplay.NextPlayerShopTurn(); // Skip turn
            }

            _soundEffects.StopWalkSound();
            _walkParticle.DisableParticle();
            _playerMovement.Move(new Vector2(0,0));
        }
    }

    void SetMoveState(float x, float y)
    {
        //If player isnt moving on Y axis but is moving on X switch between left and right
        if (x > 0 && y == 0)
        {
            _player.moveState = Character.MoveState.RIGHT;
        }
        else if (x < 0 && y == 0)
        {
            _player.moveState = Character.MoveState.LEFT;
        }
    }
}
