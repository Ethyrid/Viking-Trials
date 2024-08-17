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
        // Asegurarse de que los Canvas están en el estado correcto al inicio
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

    // Función para abrir el Canvas de Opciones
    public void AbrirOpciones()
    {
        canvasOptions.SetActive(true);
    }

    // Función para cerrar el Canvas de Opciones
    public void CerrarOpciones()
    {
        canvasOptions.SetActive(false);
    }

    // Función para alternar el estado de mute del juego
    public void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0 : 1;
    }

    // Función para alternar entre pantalla completa y ventana
    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}