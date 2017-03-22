using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingDrums : Ability {

    //Visual button indicators
    [SerializeField]private GameObject _leftTrigger;
    [SerializeField]private GameObject _rightTrigger;

    [SerializeField]private float _maxTimeToPress;
    [SerializeField]private float _maxTimeTillNextButton;
    private bool _drumming;
    private bool _mustPressLeftTrigger;
    private bool _mustPressRightTrigger;
    private float _timeToPress;
    private float _timeTillNextButton;

	void Start () {
        _abilityIsReady = true;
        _timeToPress = _maxTimeToPress;
	}
	
    public override void UseAbility()
    {
        StartDrumRhythm();
    }

    void Update()
    {
        if (_drumming)
        {
            if (_mustPressLeftTrigger || _mustPressRightTrigger)
            {
                _timeToPress -= Time.deltaTime; //Time goes down
                CheckForButtonPress();
            }

            if (_mustPressLeftTrigger && _timeToPress <= 0 || _mustPressRightTrigger && _timeToPress <= 0) //If player should press a trigger and time reaches 0
            {
                _drumming = false; //Stop drumming
            }
        }

        if (!_drumming)
        {
            StopDrumming(); //Stop using ability
        }
    }

    void StartDrumRhythm()
    {
        _drumming = true;
        //_timeTillNextButton = _maxTimeTillNextButton;
        _timeToPress = _maxTimeToPress;
        //if (_timeTillNextButton <= 0)
        //{
            ChooseRandomButton();
        //}
    }

    void ChooseRandomButton()
    {
        int randomButton = Random.Range(0, 1); //Gets random value 0 or 1
        if (randomButton == 0) // 0 = left trigger
        {
            _mustPressLeftTrigger = true;
            Debug.Log("Left Trigger");
            _leftTrigger.SetActive(true);
        }
        else if (randomButton == 1) // 1 = right trigger
        {
            _mustPressRightTrigger = true;
            Debug.Log("Right Trigger");
            _rightTrigger.SetActive(true);
        }
        _timeToPress = _maxTimeToPress; // sets the time to press to the max time to press
    }

    void CheckForButtonPress()
    {
        if (_mustPressLeftTrigger)
        {
            if (Input.GetAxis(InputAxes.TRIGGER + _player.PlayerID) <= -0.5f) //If correct trigger is pressed
            {
                Debug.Log("LT Pressed");
                _mustPressLeftTrigger = false;
                _leftTrigger.SetActive(false);
                HealPlayers();
                _timeTillNextButton = _maxTimeTillNextButton; //Sets timer for the next button
            }
            if (Input.GetAxis(InputAxes.TRIGGER + _player.PlayerID) >= 0.5f) //If wrong trigger is pressed
            {
                _drumming = false; //Stop using ability
                Debug.Log("Stop drumming");
            }
        }
        if (_mustPressRightTrigger)
        {
            if (Input.GetAxis(InputAxes.TRIGGER + _player.PlayerID) >= 0.5f)
            {
                Debug.Log("RT Pressed");
                _mustPressRightTrigger = false;
                _rightTrigger.SetActive(false);
                HealPlayers();
                _timeTillNextButton = _maxTimeTillNextButton;
            }
            if (Input.GetAxis(InputAxes.TRIGGER + _player.PlayerID) <= -0.5f)
            {
                _drumming = false;
                Debug.Log("Stop");
            }
        }
    }

    void HealPlayers()
    {
        if (this.gameObject.tag == Tags.PLAYER) //If the wardrummer is still in the player team heal all players
        {
            foreach (PlayerCharacter player in PlayerParty.PlayerCharacters)
            {
                float healthPercentage = player.MaxHealth / 100; //1% of the characters health
                if (player.CurrentHealth < player.MaxHealth)
                {
                    Debug.Log(player.CurrentHealth + " " + player.Name + " before healing");
                    player.CurrentHealth += healthPercentage * Time.deltaTime; //Heals every player for 1% of their hp
                    Debug.Log(player.CurrentHealth + " " + player.Name + "After healing");
                }
            }
        }
    }

    void StopDrumming()
    {
        _cooldown = _maxCooldown; //Resets cooldown
        _abilityIsReady = false; //Ability not ready
        _leftTrigger.SetActive(false); //Disable button indicators
        _rightTrigger.SetActive(false);
    }
}
