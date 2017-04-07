using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCharacterInfo : MonoBehaviour {

    [SerializeField]private GameObject _descriptionPanel;
    [SerializeField]private Text _classRole;
    [SerializeField]private Text _classDescription;
    private bool _isShowingDescription;

    public void ToggleDescription()
    {
        if (!_isShowingDescription)
        {
            _descriptionPanel.SetActive(true);
            _isShowingDescription = true;
        }
        else
        {
            _descriptionPanel.SetActive(false);
            _isShowingDescription = false;
        }
    }

    public void CharacterDescription(int characterNumber)
    {
        switch (characterNumber)
        {
            case 0:
                _classRole.text = "Class Role" + "\n" + "Tank";
                _classDescription.text = "Knights are frontline soldiers that can take a beating while protecting their allies." + "\n\n" +
                "Ability : Charge";
                break;
            case 1:
                _classRole.text = "Class Role"+ "\n" + "DPS";
                _classDescription.text = "Commanders have the power to bring a hail of arrows down on their enemies" + "\n\n" +
                "Ability : Arrow Rain";
                break;
            case 2:
                _classRole.text = "Class Role" + "\n" + "DPS";
                _classDescription.text = "Warriors tend to be flexible on the battlefield they can deal devastating blows while taking a few hits" + "\n\n" + 
                "Ability : Whirlwind";
                break;
            case 3:
                _classRole.text = "Class Role" + "\n" + "Support";
                _classDescription.text = "Wardrummers use special rhythmic techniques to heal their allies" + "\n\n" +
                "Ability : Healing Rhythm";
                break;
        }
    }
}
