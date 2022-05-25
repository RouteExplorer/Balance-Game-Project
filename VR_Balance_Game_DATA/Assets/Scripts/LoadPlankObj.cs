using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class LoadPlankObj : MonoBehaviour
{
    public GameObject plank;
    void Start()
    {
        string save = File.ReadAllText(Application.dataPath + "/Saves/save.txt");
        SaveObject loaded = JsonUtility.FromJson<SaveObject>(save);

        Debug.Log("loaded plank"+loaded.plankSize+"current plank"+ plank.transform.localScale);
      
        plank.transform.localScale = loaded.plankSize;

        Debug.Log("After load plank" + plank.transform.localScale);
    }
    private class SaveObject
    {
        public int currentScene;
        public Vector3 plankSize;
    }
}

