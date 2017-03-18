using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopPhaseTurns : MonoBehaviour {

    [SerializeField]private StandaloneInputModule _inputs;
    private ChangePortraitColor _playerPortrait;
    private ShopDisplay _shopDisplay;

    private int _playerToShop = 1;
    public int PlayerToShop
    {
        get { return _playerToShop; }
        set { _playerToShop = value; }
    }

    void Awake()
    {
        _playerPortrait = GameObject.FindGameObjectWithTag(Tags.PLAYERHUDS).GetComponent<ChangePortraitColor>();
        _shopDisplay = GetComponent<ShopDisplay>();
    }

    public void SetShopInputs()
    {
        //Sets input to every individual player during his turn
        _inputs.horizontalAxis = InputAxes.LEFT_JOYSTICK_X + _playerToShop;
        _inputs.verticalAxis = InputAxes.LEFT_JOYSTICK_Y + _playerToShop;
        _inputs.submitButton = InputAxes.XBOX_A + _playerToShop;
        _inputs.cancelButton = InputAxes.XBOX_B + _playerToShop;
    }

    public void ShowPlayerToShop()
    {
        for (int i = 0; i < PlayerParty.PlayerCharacters.Count; i++)
        {
            if (PlayerParty.PlayerCharacters[i] == _shopDisplay.MatchingPlayer)
            {
                _playerPortrait.SetPortraitActive(PlayerParty.PlayerCharacters[i].HUD.Portrait);
            }
            else
            {
                _playerPortrait.SetPortraitInactive(PlayerParty.PlayerCharacters[i].HUD.Portrait);
            }
        }
    }

    public void ResetPortraitColors()
    {
        for (int i = 0; i < PlayerParty.PlayerCharacters.Count; i++)
        {
            _playerPortrait.SetPortraitActive(PlayerParty.PlayerCharacters[i].HUD.Portrait);
            PlayerParty.PlayerCharacters[i].RestoreHealth();
        }
    }
}
