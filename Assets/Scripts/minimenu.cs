using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMiniMenu : MonoBehaviour
{
    public GameObject canvasMenu;

    void Start()
    {
        // Desactiva el Canvas al iniciar
        canvasMenu.SetActive(false);
    }

    void Update()
    {
        // Activa o desactiva el Canvas al presionar la tecla "Esc"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Tecla Escape presionada");
            canvasMenu.SetActive(!canvasMenu.activeSelf);
            //canvasMenu.SetActive(true);
        }
    }

    // Funci�n para desactivar el Canvas (volver al juego)
    public void DesactivarMenu()
    {
        canvasMenu.SetActive(false);
    }

    // Funci�n para ir al Men� Principal
    public void IrAMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal"); // Reemplaza "MenuPrincipal" con el nombre de tu escena del men� principal
    }
}