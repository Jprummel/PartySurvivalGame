using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UnlockChecker : MonoBehaviour {

    [SerializeField]private GameObject  _notificationObject;
    [SerializeField]private Text        _unlockNotificationText;
    [SerializeField]private int         _waveRequiredForUnlock;

    private string          _currentLevel;
    private SaveLoadData    _saveData;

    void Awake()
    {
        //_saveData = GameObject.FindGameObjectWithTag(Tags.SAVELOADOBJECT).GetComponent<SaveLoadData>();
        Scene scene = SceneManager.GetActiveScene();
        _currentLevel = scene.name;
    }

	void Update () {
		if(GameInformation.Wave == _waveRequiredForUnlock){
            Unlock(_currentLevel);
        }
	}

    void Unlock(string currentLevel)
    {
        switch (currentLevel)
        {
            case MapNames.BATTLEFIELD:
                if (!LockData.ExecutionersRoadUnlocked)
                {
                    LockData.UnlockMap(MapNames.EXECUTIONERSROAD);
                    ShowUnlockNotification(MapNames.EXECUTIONERSROAD);
                }
                break;
            case MapNames.EXECUTIONERSROAD:
                if (!LockData.DungeonsUnlocked)
                {
                    LockData.UnlockMap(MapNames.DUNGEONS);
                    ShowUnlockNotification(MapNames.DUNGEONS);
                }
                break;
            case MapNames.DUNGEONS:
                if (!LockData.ThroneRoomUnlocked)
                {
                    LockData.UnlockMap(MapNames.THRONEROOM);
                    ShowUnlockNotification(MapNames.THRONEROOM);
                }
                break;
            default:
                break;
        }
        _saveData.SaveGameData();
    }

    IEnumerator ShowUnlockNotification(string unlockedLevel)
    {
        _unlockNotificationText.text = "You now have access to " + unlockedLevel;
        _unlockNotificationText.DOFade(1, 0.5f);
        yield return new WaitForSeconds(1);
        _unlockNotificationText.DOFade(0, 0.5f);
    }
}