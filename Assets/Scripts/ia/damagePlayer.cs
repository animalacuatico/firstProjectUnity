using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<charControllerv2>())
        {
            Debug.Log("Damage taken");
            gameManager.instance.playerHealth = gameManager.instance.playerHealth - 1;
        }
    }
}
