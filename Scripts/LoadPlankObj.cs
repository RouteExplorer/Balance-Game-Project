using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class LoadPlankObj : MonoBehaviour
{
    public GameObject plank;
    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    public void Load()
    {
        string save = File.ReadAllText(Application.dataPath + "/Saves/save.txt");
        SaveObject loaded = JsonUtility.FromJson<SaveObject>(save);

        Debug.Log("loaded plank");

        plank.transform.localScale = loaded.plankSize;
    }
    private class SaveObject
    {
        public int currentScene;
        public Vector3 plankSize;
    }
}

