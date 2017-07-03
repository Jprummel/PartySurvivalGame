using UnityEngine;

public class ControllerInput : MonoBehaviour {

    private ShopDisplay _shopDisplay;
    private WalkParticle _walkParticle;
    private CharacterSoundFX _soundEffects;
    private WaveController _waveController;
    private PauseGame _pauseGame;
    private PlayerScriptCollector _playerScripts;

    void Awake()
    {
        _shopDisplay    = GameObject.FindGameObjectWithTag(Tags.SHOPMANAGER).GetComponent<ShopDisplay>();
        _pauseGame      = GameObject.FindGameObjectWithTag(Tags.PAUSEOBJECT).GetComponent<PauseGame>();
        _walkParticle   = GetComponentInChildren<WalkParticle>();
        _soundEffects   = GetComponent<CharacterSoundFX>();
        _waveController = GameObject.FindGameObjectWithTag(Tags.WAVEMANAGER).GetComponent<WaveController>();
        _playerScripts  = GetComponent<PlayerScriptCollector>();
    }

    void Update()
    {
        ControllerInputs();
    }

    void ControllerInputs()
    {
        if (_waveController.IsCombatPhase && !_pauseGame.GameIsPaused && !_playerScripts.Player.IsDead)
        {
            if (_playerScripts.Player.Ability != null)
            {
                if (Input.GetButtonDown(InputAxes.XBOX_A + _playerScripts.Player.PlayerID))
                {
                    _playerScripts.Player.Ability.UseAbility();
                }

                if (Input.GetButtonDown(InputAxes.XBOX_B + _playerScripts.Player.PlayerID) && _playerScripts.Player.Ability.UsingAbility)
                {
                    if (_playerScripts.Player.Ability.UsingAbility)
                    {
                        _playerScripts.Player.Ability.CancelAbility();
                    }
                }
            }

            if (Input.GetButtonDown(InputAxes.XBOX_X + _playerScripts.Player.PlayerID) && _playerScripts.PlayerAttack.ReadyToAttack)
            {
                _playerScripts.PlayerAttack.Attack();
            }

            if (Input.GetButtonDown(InputAxes.XBOX_Y + _playerScripts.Player.PlayerID) && _playerScripts.PlayerAttack.ReadyToAttack)
            {
                //Heavy Attack
                _playerScripts.PlayerAttack.HeavyAttack();
            }
            if (_playerScripts.Player.CanMove)
            {
                if (Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _playerScripts.Player.PlayerID) != 0 || Input.GetAxis(InputAxes.LEFT_JOYSTICK_Y + _playerScripts.Player.PlayerID) != 0)
                {
                    float x = Input.GetAxis(InputAxes.LEFT_JOYSTICK_X + _playerScripts.Player.PlayerID);
                    float y = Input.GetAxis(InputAxes.LEFT_JOYSTICK_Y + _playerScripts.Player.PlayerID);
                    Vector2 moveDir = new Vector2(x, y);
                    _playerScripts.PlayerMovement.Move(moveDir.normalized);
                    SetMoveState(x, y);
                    _soundEffects.PlayWalkAudio();
                    if (x != 0)
                    {
                        // _walkParticle.ShowParticle(); // only show particle when player isnt running straight up or down
                    }
                }
                else
                {
                    _playerScripts.PlayerMovement.Move(new Vector2(0, 0));
                    //_walkParticle.DisableParticle();
                    _soundEffects.StopWalkSound();
                }
            }
            else if (!_playerScripts.Player.CanMove)
            {
                _playerScripts.Player.UpperBodyAnimator.SetBool("IsWalking", false);//Test
                _playerScripts.Player.LowerBodyAnimator.SetBool("IsWalking", false);//Test
            }
        }

        if (Input.GetButtonDown(InputAxes.START + _playerScripts.Player.PlayerID) && _waveController.IsCombatPhase)
        {
            _pauseGame.TogglePause();
        }

        if (!_waveController.IsCombatPhase)
        {
            if (Input.GetButtonDown(InputAxes.XBOX_B + _playerScripts.Player.PlayerID) && _shopDisplay.MatchingPlayer == _playerScripts.Player && _shopDisplay.ShopIsOpen) //If player presses B while its his turn and the shop is open
            {
                _shopDisplay.NextPlayerShopTurn(); // Skip turn
            }

            _soundEffects.StopWalkSound();
            _walkParticle.DisableParticle();
            _playerScripts.PlayerMovement.Move(new Vector2(0, 0));
        }
    }

    void SetMoveState(float x, float y)
    {
        //If player isnt moving on Y axis but is moving on X switch between left and right
        if (x > 0)
        {
            _playerScripts.Player.moveState = Character.MoveState.RIGHT;
        }
        else if (x < 0)
        {
            _playerScripts.Player.moveState = Character.MoveState.LEFT;
        }
    }
}
