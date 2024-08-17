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

    // Funci�n para ir al Men� Principal
    public void IrAMenuPrincipal()
    {
        SceneManager.LoadScene("MainMenu"); // Reemplaza "MenuPrincipal" con el nombre de tu escena del men� principal
    }
}