using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarDrummer : PlayerCharacter{

    void Start()
    {
        _ability = GetComponent<HealingDrums>();
        Name = "Wardrummer";
    }
}
