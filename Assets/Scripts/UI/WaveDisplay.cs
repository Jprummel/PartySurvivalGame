using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveDisplay : MonoBehaviour {

    [SerializeField]private Text _waveNumber;
    
    void Update()
    {
        DisplayWaveNumber();
    }

    void DisplayWaveNumber()
    {
        _waveNumber.text = "Wave: " +  GameInformation.Wave.ToString();
    }
}
