using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinBehavior : MonoBehaviour
{
    public int coinValue = 1;
    private void OnTriggerEnter(Collider collider)
    {
        charControllerv2 charController = collider.GetComponent<charControllerv2>();
        if (charController != null)
        {
            gameManager.instance.IncreasePoint();
            Destroy(this.gameObject);
        }
    }
}
