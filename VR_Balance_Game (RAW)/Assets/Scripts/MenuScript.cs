using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuScript : MonoBehaviour
{
    public static int SaveScene;
    public GameObject plank;
    public GameObject popup;
    [SerializeField] private AudioMixer audioMixer;

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

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
    public void SaveCurrent()
    {
        SaveScene = SceneManager.GetActiveScene().buildIndex;
        Save();
    }
    public void Save()
    {
        SaveObject saveData = new SaveObject
        {
            currentScene = SaveScene,
            plankSize = plank.transform.localScale,
        };
        Debug.Log(plank.transform.localScale+"saved");

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.dataPath + "/Saves/save.txt", json);
    }
    private class SaveObject
    {
        public int currentScene;
        public Vector3 plankSize;
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
        }
    }
    
}

