using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuScript : MonoBehaviour
{
    public static int SaveScene;
    public GameObject plank;
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
        SaveObject saveData = new SaveObject
        {
            currentScene = SaveScene,
            plankSize = plank.transform.localScale,
        };

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.dataPath + "/Saves/save.txt", json);
    }
    public void Load()
    {

        string save = File.ReadAllText(Application.dataPath + "/Saves/save.txt");
        SaveObject loaded = JsonUtility.FromJson<SaveObject>(save);

        Debug.Log(loaded.currentScene);
        Debug.Log(loaded.plankSize);

        CharacterMovementHelper.plankSize = loaded.plankSize;
        SceneManager.LoadScene(loaded.currentScene);
        




    }
    private class SaveObject
    {
        public int currentScene;
        public Vector3 plankSize;
    }
}

