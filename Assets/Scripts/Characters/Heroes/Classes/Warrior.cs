using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerCharacter {

    void Start()
    {
        _ability = GetComponent<Whirlwind>();
        name = "Warrior";
        _damageScaleFactor = 1.2f;
        _healthScaleFactor = 1.2f;
    }
}
