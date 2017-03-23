using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopPhaseTurns : MonoBehaviour {

    [SerializeField]private StandaloneInputModule _inputs;
    private int _playerToShop = 1;
    public int PlayerToShop
    {
        get { return _playerToShop; }
        set { _playerToShop = value; }
    }

    public void SetShopInputs()
    {
        //Sets input to every individual player during his turn
        _inputs.horizontalAxis = InputAxes.LEFT_JOYSTICK_X + _playerToShop;
        _inputs.verticalAxis = InputAxes.LEFT_JOYSTICK_Y + _playerToShop;
        _inputs.submitButton = InputAxes.XBOX_A + _playerToShop;
        _inputs.cancelButton = InputAxes.XBOX_B + _playerToShop;
    }

    public void RestorePlayerHealth()
    {
        for (int i = 0; i < PlayerParty.PlayerCharacters.Count; i++)
        {
            PlayerParty.PlayerCharacters[i].RestoreHealth();
        }
    }
}
