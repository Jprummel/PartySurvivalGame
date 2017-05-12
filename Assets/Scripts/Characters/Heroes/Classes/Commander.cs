using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : PlayerCharacter {

    void Start()
    {
        _ability = GetComponent<ArrowRain>();
        Name = "Commander";
        _damageScaleFactor = 1.5f;
        _healthScaleFactor = 1.3f;

    }

}
