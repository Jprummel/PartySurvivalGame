using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgrade{

    //Upgrade Interface
	void Upgrade(PlayerCharacter character);
    void DetermineNewCost();
}
