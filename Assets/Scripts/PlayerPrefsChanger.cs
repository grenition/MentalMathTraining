using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsChanger : MonoBehaviour
{
    public string playerPrefsName = "TutorialLock";
    public Toggle toggle;
    private void Start()
    {
        if(toggle != null)
        {
            if (PlayerPrefs.HasKey(playerPrefsName))
            {
                toggle.isOn = GetBool();
            }
            toggle.onValueChanged.AddListener(ChangeBool);
        }
    }
    public void ChangeBool(bool value)
    {
        if (value)
        {
            PlayerPrefs.SetInt(playerPrefsName, 1);
        }
        else
        {
            PlayerPrefs.SetInt(playerPrefsName, 0);
        }
        Debug.Log(PlayerPrefs.GetInt(playerPrefsName));
    }
    public bool GetBool()
    {
        if(PlayerPrefs.GetInt(playerPrefsName) == 1)
            return true;
        else
            return false;
    }
}
