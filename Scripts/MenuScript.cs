using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuScript : MonoBehaviour
{
    public static int SaveScene;
    public static Vector3 plank;
    public GameObject popup;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SaveScene);

    }
    public void Save()
    {

        string check = File.ReadAllText(Application.dataPath + "/Saves/save.txt");

        Debug.Log("Saved");

        if (check != null)
        {
            //warnn user of overwriting data
        }

        SaveObject saveData = new SaveObject
        {
            currentScene = SaveScene,
            plankSize = plank,
        };

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.dataPath + "/Saves/save.txt", json);
    }
    public void Load()
    {
        string save = File.ReadAllText(Application.dataPath + "/Saves/save.txt");
        SaveObject loaded = JsonUtility.FromJson<SaveObject>(save);

        Debug.Log("loaded");
        if (loaded == null)
        {
            popup.SetActive(true);
            return;
        }

        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(loaded.currentScene);
            plank = loaded.plankSize;

        }
        plank = loaded.plankSize;
        //CharacterMovementHelper.plankSize = loaded.plankSize;
    }
    private class SaveObject
    {
        public int currentScene;
        public Vector3 plankSize;
    }
}

