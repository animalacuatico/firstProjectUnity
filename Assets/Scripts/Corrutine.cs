using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrutine : MonoBehaviour
{
    public TMPro.TMP_Text point;
    void Start()
    {
        point = GetComponent<TMPro.TMP_Text>();
    }
    void Update()
    {
        point.text = "Coins: " + gameManager.instance.coins;
    }
    IEnumerator Fade()
    {
        for (float i = 1f; i >= 0f; i -= 0.2f)
        {
            Color c = point.color;
            c.a = i;
            point.color = c;
            yield return new WaitForSeconds(0.1f);
        }
        for (float i = 0f; i <= 1f; i += 0.2f)
        {
            Color c = point.color;
            c.a = i;
            point.color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void StartFade()
    {
        StartCoroutine(Fade());
    }
}
