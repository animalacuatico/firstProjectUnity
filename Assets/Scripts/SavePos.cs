using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // Permite trabajar con sistemas de archivos

public class SavePos : MonoBehaviour
{
    void Start()
    {
        StreamReader sr = new StreamReader(Application.persistentDataPath + "/saveposition.text");
        float x = float.Parse(sr.ReadLine()), y = float.Parse(sr.ReadLine()), z = float.Parse(sr.ReadLine()); // Lee el archivo para obtener las coordenadas de xyz.
        transform.position = new Vector3(x, y, z);
        sr.Close();

        StreamReader srPoints = new StreamReader(Application.persistentDataPath + "/savecoins.text");
        gameManager.instance.coins = float.Parse(srPoints.ReadLine());
        srPoints.Close();
    }
    private void OnDisable()
    {
        // Para guardar la posición
        FileStream fs = File.Create(Application.persistentDataPath + "/saveposition.text"); // Crea un archivo y donde lo guarda.
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine(transform.position.x);
        sw.WriteLine(transform.position.y);
        sw.WriteLine(transform.position.z);
        sw.Close();
        fs.Close();
        FileStream fsPoints = File.Create(Application.persistentDataPath + "/savecoins.text");
        StreamWriter swPoints = new StreamWriter(fsPoints);
        swPoints.WriteLine(gameManager.instance.GetCoins());
        swPoints.Close();
        fsPoints.Close();
    }
}
