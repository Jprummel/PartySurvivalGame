using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : PlayerCharacter {

    void Start()
    {
        _ability = GetComponent<Charge>();
        Name = "Knight";
        _damageScaleFactor = 1.1f;
        _healthScaleFactor = 1.3f;
    }
}