using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum InterfaceVariable { COINS };
public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public float coins = 0;
    public GameObject Corrutine;
    //private Corrutine text; comentado para evitar error
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
    public void ManipulateCoins(int value)
    {
        coins += value;
    }
    public float GetCoins()
    {
        return coins;
    }
}
