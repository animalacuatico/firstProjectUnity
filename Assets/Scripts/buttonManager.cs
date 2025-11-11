using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonManager : MonoBehaviour
{
    public void LoadMenuScene()
    {
        gameManager.instance.ChangeScene("Menu");
    }
    public void LoadPlatformer()
    {
        gameManager.instance.ChangeScene("Juego");
    }
    public void ExitApp()
    {
        Application.Quit();
    }
}
