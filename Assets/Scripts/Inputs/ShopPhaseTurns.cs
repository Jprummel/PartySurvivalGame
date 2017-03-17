using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopPhaseTurns : MonoBehaviour {

    [SerializeField]private StandaloneInputModule _inputs;
    private ShopDisplay _shopDisplay;

    private int _playerToShop = 1;
    public int PlayerToShop
    {
        get { return _playerToShop; }
        set { _playerToShop = value; }
    }
    private Color _inActiveColor;
    private Color _defaultColor;

    void Awake()
    {
        _shopDisplay = GetComponent<ShopDisplay>();
        _defaultColor = new Color(255,255,255,1);
        _inActiveColor = new Color(0.20f, 0.20f, 0.20f, 1);
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
                PlayerParty.PlayerCharacters[i].HUD.Portrait.color = PlayerParty.PlayerCharacters[i].HUD.DefaultColor;
            }
            else
            {
                PlayerParty.PlayerCharacters[i].HUD.Portrait.color = PlayerParty.PlayerCharacters[i].HUD.InactiveColor;
            }
        }
    }

    public void ResetPortraitColors()
    {
        for (int i = 0; i < PlayerParty.PlayerCharacters.Count; i++)
        {
            PlayerParty.PlayerCharacters[i].HUD.Portrait.color = _defaultColor;
            PlayerParty.PlayerCharacters[i].RestoreHealth();
        }
    }
}
