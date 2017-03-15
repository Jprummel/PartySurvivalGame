﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

    private WalkParticle    _walkParticle;
    private WaveController  _waveController;
    private PauseGame       _pauseGame;
    private PlayerCharacter _player;
    private PlayerMovement  _playerMovement;
    private PlayerAttack    _playerAttack;

    void Awake()
    {
        _walkParticle   = GetComponentInChildren<WalkParticle>();
        _waveController = GameObject.FindGameObjectWithTag(Tags.WAVEMANAGER).GetComponent<WaveController>();
        _pauseGame      = GetComponent<PauseGame>();
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
        if (_waveController.IsCombatPhase && !_pauseGame.GameIsPaused)
        {
            if (Input.GetButtonDown(InputAxes.XBOX_A + _player.PlayerID))
            {
                //Ability 1
            }

            if (Input.GetButtonDown(InputAxes.XBOX_B + _player.PlayerID))
            {
                //Ability 2
            }

            if (Input.GetButtonDown(InputAxes.XBOX_X + _player.PlayerID))
            {
                _playerAttack.Attack();
            }

            if (Input.GetButtonDown(InputAxes.XBOX_Y + _player.PlayerID))
            {
                //Heavy Attack
            }

            if (Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _player.PlayerID) != 0 || Input.GetAxis(InputAxes.LEFT_JOYSTICK_Y + _player.PlayerID) != 0)
            {
                float x = Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _player.PlayerID);
                float y = Input.GetAxis(InputAxes.LEFT_JOYSTICK_Y + _player.PlayerID);
                Vector2 moveDir = new Vector2(x, y);
                _playerMovement.Move(moveDir.normalized);
                _walkParticle.ShowParticle();
            }
            else
            {
                _playerMovement.Move(new Vector2(0, 0));
                _walkParticle.DisableParticle();
            }            
        }
        
        if (Input.GetButtonDown(InputAxes.START + _player.PlayerID))
        {
            _pauseGame.TogglePause();
        }
    }
}