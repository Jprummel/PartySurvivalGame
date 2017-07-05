using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadData : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        LoadGameData();

    }

    public void SaveGameData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveDataSlot.dat");

        SaveData saveData = new SaveData();

        saveData.ExecutionersRoadUnlocked   = LockData.ExecutionersRoadUnlocked;
        saveData.DungeonsUnlocked           = LockData.DungeonsUnlocked;
        saveData.ThroneRoomUnlocked         = LockData.ThroneRoomUnlocked;

        bf.Serialize(file, saveData);
        file.Close();
    }

    public void LoadGameData()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveDataSlot.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveDataSlot.dat", FileMode.Open);

            SaveData saveData = (SaveData)bf.Deserialize(file);

            LockData.ExecutionersRoadUnlocked   = saveData.ExecutionersRoadUnlocked;
            LockData.DungeonsUnlocked           = saveData.DungeonsUnlocked;
            LockData.ThroneRoomUnlocked         = saveData.ThroneRoomUnlocked;

            file.Close();
        }
    }
}

[System.Serializable]
public class SaveData
{
    public bool ExecutionersRoadUnlocked;
    public bool DungeonsUnlocked;
    public bool ThroneRoomUnlocked;
}
