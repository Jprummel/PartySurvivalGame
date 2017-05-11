using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class DisplayStats : MonoBehaviour {

    [SerializeField]private Image _portrait;
    [SerializeField]private Text _playerNumberText;
    [SerializeField]private Text _statDisplayText;
    [SerializeField]private Text _statValuesText;
    [SerializeField]private Text _availableGold;
    [SerializeField]private Text _totalEarnedGold;
    [SerializeField]private PlayerCharacter _player;
    private ShopDisplay _display;
    private float _gold = 0;
    private float _earnedGold;

    public float Gold
    {
        get { return _gold; }
        set { _gold = value; }
    }

    public float EarnedGold
    {
        get { return _earnedGold; }
        set { _earnedGold = value; }
    }


    void Start () {
        _display = GameObject.FindGameObjectWithTag(Tags.SHOPMANAGER).GetComponent<ShopDisplay>();
        
	}
	
	void Update () {
        if(_display.MatchingPlayer != null){
            DisplayPortrait();
            DisplayPlayerNumber();
            DisplayStatValues();
            DisplayAvailableGold();
            DisplayTotalEarnedGold();
            DisplayStatNames();
        }
    }

    void DisplayPortrait()
    {
        _portrait.sprite = _display.MatchingPlayer.Portrait;
    }

    void DisplayPlayerNumber()
    {
        _playerNumberText.text = "Player " + _display.MatchingPlayer.PlayerID;
    }

    void DisplayStatNames()
    {
        _statDisplayText.text = "Class" + "\n" +
                                "Damage" + "\n" +
                                "Health" + "\n" +
                                "Move Speed";   
    }

    void DisplayStatValues()
    {
        _statValuesText.text =  _display.MatchingPlayer.Name + "\n" +
                                _display.MatchingPlayer.Damage + "\n" +
                                _display.MatchingPlayer.MaxHealth + "\n" +
                                _display.MatchingPlayer.MovementSpeed;
    }

    void DisplayAvailableGold()
    {
        DOTween.To(()=> Gold,x => Gold = x ,_display.MatchingPlayer.Gold, 0.25f);
        _availableGold.text = "Gold : " + _gold.ToString("N0");
    }

    void DisplayTotalEarnedGold()
    {
        DOTween.To(() => EarnedGold, x => EarnedGold = x, _display.MatchingPlayer.TotalGoldEarned, 1f);
        _totalEarnedGold.text = "Total Earned : " + _earnedGold.ToString("N0");
    }
}
