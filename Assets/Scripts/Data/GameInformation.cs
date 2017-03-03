using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoBehaviour {

    public static List<PlayerCharacter> JoinedPlayers = new List<PlayerCharacter>();
    public static int HighestWave;
    public static int Wave = 1;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
