using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public float coins = 0;
    public GameObject Corrutine;
    private Corrutine text;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void IncreasePoint()
    {
        coins++;
        text.StartFade();
    }
    public void Start()
    {
        text = FindObjectOfType<Corrutine>();
    }
    public float GetCoins()
    {
        return coins;
    }
    public string GetCurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        return currentScene;
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
