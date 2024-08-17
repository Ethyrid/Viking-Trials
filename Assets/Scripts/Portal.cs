using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Nombre de la escena de "ganar"
    public string winSceneName = "WinScene";

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en contacto es el jugador
        if (other.CompareTag("Player"))
        {
            // Cargar la escena de "ganar"
            SceneManager.LoadScene(winSceneName);
        }
    }
}
