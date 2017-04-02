using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerCharacter {

    void Start()
    {
        _ability = GetComponent<Whirlwind>();
        name = "Warrior";
    }
}
