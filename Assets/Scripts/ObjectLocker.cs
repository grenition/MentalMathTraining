using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLocker : MonoBehaviour
{
    public string parametrName = "TutorialLock";
    public GameObject[] objectsToLock;

    private void Start()
    {
        LockObjects();
    }
    public void LockObjects()
    {
        if (!PlayerPrefs.HasKey(parametrName))
            return;

        bool state = PlayerPrefs.GetInt(parametrName) != 1;

        foreach(GameObject obj in objectsToLock)
        {
            obj.SetActive(state);
            Debug.Log(obj.name + " " + obj.activeSelf.ToString());
        }
    }
}
