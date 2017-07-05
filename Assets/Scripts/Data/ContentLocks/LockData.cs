using UnityEngine;

public class LockData : MonoBehaviour {

    public static bool ExecutionersRoadUnlocked;
    public static bool DungeonsUnlocked;
    public static bool ThroneRoomUnlocked;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    public static void UnlockMap(string mapToUnlock)
    {
        switch (mapToUnlock)
        {
            case MapNames.EXECUTIONERSROAD:
                ExecutionersRoadUnlocked = true;
                break;
            case MapNames.DUNGEONS:
                DungeonsUnlocked = true;
                break;
            case MapNames.THRONEROOM:
                ThroneRoomUnlocked = true;
                break;
            default:
                break;
        }
    }	
}
