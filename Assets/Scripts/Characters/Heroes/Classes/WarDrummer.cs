using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarDrummer : PlayerCharacter{

    void Start()
    {
        _abilityOne = GetComponent<HealingDrums>();
        Name = "Wardrummer";
    }
}
