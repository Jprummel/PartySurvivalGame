using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveDisplay : MonoBehaviour {

    [SerializeField]private Text _waveNumber;
    public delegate void UpdateWave();
    public static UpdateWave updateWave;
    
    void Update()
    {
        if(updateWave != null)
        {
            DisplayWaveNumber();
            updateWave = null;
        }
    }

    void DisplayWaveNumber()
    {
        _waveNumber.text = "Wave: " +  GameInformation.Wave.ToString();
    }
}
