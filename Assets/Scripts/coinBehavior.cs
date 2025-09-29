using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinBehavior : MonoBehaviour
{
    public int coinValue = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<charController>())
        {
            gameManager.instance.ManipulateCoins(coinValue);
            Debug.Log("Monedas: " + gameManager.instance.GetCoins());
            Destroy(gameObject);
        }
    }
}
