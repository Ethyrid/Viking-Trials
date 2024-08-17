using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlMenu : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject canvasOptions;
    private bool isMuted = false;

    void Start()
    {
        // Asegurarse de que los Canvas est�n en el estado correcto al inicio
        canvasMenu.SetActive(true);
        canvasOptions.SetActive(false);
    }

    void Update()
    {
        // Activa o desactiva el Canvas de opciones al presionar la tecla "Esc"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvasOptions.activeSelf)
            {
                canvasOptions.SetActive(false);
            }
            else
            {
                canvasOptions.SetActive(true);
            }
        }
    }

    // Funci�n para abrir el Canvas de Opciones
    public void AbrirOpciones()
    {
        canvasOptions.SetActive(true);
    }

    // Funci�n para cerrar el Canvas de Opciones
    public void CerrarOpciones()
    {
        canvasOptions.SetActive(false);
    }

    // Funci�n para alternar el estado de mute del juego
    public void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0 : 1;
    }

    // Funci�n para alternar entre pantalla completa y ventana
    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}