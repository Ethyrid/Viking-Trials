using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    public GameObject canvasMenu;

    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Función para ir al Menú Principal
    public void IrAMenuPrincipal()
    {
        SceneManager.LoadScene("MainMenu"); // Reemplaza "MenuPrincipal" con el nombre de tu escena del menú principal
    }
}