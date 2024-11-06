using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private int[] puntuacion;

    //Patrón de diseño Singletone --> Es una variable unica y accesible en toda la app.
    public static GameManager instance;
    //Instancia de la clase dentro de la propia clase.
    



    // Awake is called before the Start. Inicializar las cosas antes de los starts.
    void Awake()
    {

        if (!instance)
        {
            //Establecemos el nuevo Game Manager.
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
            



    }


    private void Start()
    {
        puntuacion = new int[2];
    }

    public int GetIndexPuntuacion(int index)
    {
        return puntuacion[index];
    }


    public void SetIndexPuntuacion(int index, int nValue)
    {
        puntuacion[index]= nValue;
    }


    public void ChangeScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);


    }


}
