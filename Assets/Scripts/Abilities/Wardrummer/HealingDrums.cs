using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingDrums : Ability {

    //Visuals
    [SerializeField]private GameObject _leftTrigger;
    [SerializeField]private GameObject _rightTrigger;
    [SerializeField]private GameObject _healingCircle;
    [SerializeField]private Transform _circleSpawnPosition;
    private GameObject _circle;
    //Ability variables
    [SerializeField]private float _maxTimeToPress;
    [SerializeField]private float _maxTimeTillNextButton;
    private bool _mustPressLeftTrigger;
    private bool _mustPressRightTrigger;
    private float _timeToPress;
    private float _timeTillNextButton;

	void Start () {
        _abilityIsReady = true;
	}
	
    public override void UseAbility()
    {
        StartDrumRhythm();
    }

    protected override void Update()
    {
        base.Update();
        if (_usingAbility)
        {
            if (_mustPressLeftTrigger || _mustPressRightTrigger)
            {
                _timeToPress -= Time.deltaTime; //Time goes down
                CheckForButtonPress();
            }

            if (_mustPressLeftTrigger && _timeToPress <= 0 || _mustPressRightTrigger && _timeToPress <= 0) //If player should press a trigger and time reaches 0
            {
                _usingAbility = false; //Stop drumming
            }
            if (!_mustPressLeftTrigger && !_mustPressRightTrigger)
            {
                _timeTillNextButton -= Time.deltaTime;
                if (_timeTillNextButton <= 0)
                {
                    ChooseRandomButton();
                }
            }
            //HealPlayers();
        }

        if (!_usingAbility)
        {
            StopDrumming(); //Stop using ability
        }
    }

    void StartDrumRhythm()
    {
        SpawnHealingCircle();
        _player.CharacterAnimator.SetBool("IsMoving", false);
        _player.CharacterAnimator.SetBool("UseAbility",true);
        _player.CanMove = false; //Player can't move while drumming
        _usingAbility = true;
        _abilityIsReady = false;
        _timeToPress = 1.5f;
        ChooseRandomButton();
    }

    void SpawnHealingCircle()
    {
        _circle = Instantiate(_healingCircle, this.transform);
        _circle.transform.position = _circleSpawnPosition.position;
    }

    void ChooseRandomButton()
    {
        int randomButton = Random.Range(0, 2); //Gets random value 0 or 1
        if (randomButton == 0) // 0 = left trigger
        {
            _mustPressLeftTrigger = true;
            _leftTrigger.SetActive(true);
        }
        else if (randomButton == 1) // 1 = right trigger
        {
            _mustPressRightTrigger = true;
            _rightTrigger.SetActive(true);
        }
        _timeToPress = _maxTimeToPress; // sets the time to press to the max time to press
    }

    void CheckForButtonPress()
    {
        if (_mustPressLeftTrigger)
        {
            if (Input.GetAxis(InputAxes.TRIGGER + _player.PlayerID) < 0) //If correct trigger is pressed
            {
                _mustPressLeftTrigger = false;
                _leftTrigger.SetActive(false);
                _timeTillNextButton = _maxTimeTillNextButton; //Sets timer for the next button
            }
            if (Input.GetAxis(InputAxes.TRIGGER + _player.PlayerID) > 0) //If wrong trigger is pressed
            {
                _usingAbility = false; //Stop using ability
            }
        }
        if (_mustPressRightTrigger)
        {
            if (Input.GetAxis(InputAxes.TRIGGER + _player.PlayerID) > 0)
            {
                Debug.Log("Pressed RT");
                _mustPressRightTrigger = false;
                _rightTrigger.SetActive(false);
                _timeTillNextButton = _maxTimeTillNextButton;
            }
            if (Input.GetAxis(InputAxes.TRIGGER + _player.PlayerID) < 0)
            {
                _usingAbility = false;
            }
        }
    }

    public void Heal(Character character)
    {
        float healthPercentage = character.MaxHealth / 40;
        character.CurrentHealth += healthPercentage * Time.deltaTime;
        _player.Gold = Mathf.Round(_player.Gold + 2 * Time.deltaTime);
    }

    void StopDrumming()
    {
        DestroyImmediate(_circle);
        _cooldown = _maxCooldown; //Resets cooldown
        _player.CharacterAnimator.SetBool("UseAbility",false);
        _player.CanMove = true; //Player can move again
        _abilityIsReady = false; //Ability not ready
        _leftTrigger.SetActive(false); //Disable button indicators
        _rightTrigger.SetActive(false);
    }

    public override void CancelAbility()
    {
        StopDrumming();
    }
}
