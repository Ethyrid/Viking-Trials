using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Namespace dedicado a el manejo de escenas dentro de Unity

public class Menu : MonoBehaviour
{
    public void ButtonStart()//Metodo publico creado para el boton de Start
    {
        SceneManager.LoadScene(1); // Carga la escena del id que esta entre parentesis
    }

    public void ButtonExit() //Metodo publico creado para el boton de Exit
    {
        Application.Quit(); // Metodo que cierra la aplicacion
    }
}