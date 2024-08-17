using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPosition;

    void Start()
    {
        // Inicializar la posici�n de respawn en la posici�n inicial del jugador
        respawnPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el jugador toca el agua
        if (other.CompareTag("Water"))
        {
            Respawn();
        }

        // Verificar si el jugador toca un checkpoint
        if (other.CompareTag("Checkpoint"))
        {
            // Actualizar la posici�n de respawn
            respawnPosition = other.transform.position;
        }
    }

    public void Respawn()
    {
        // Reiniciar la posici�n del jugador a la posici�n de respawn
        transform.position = respawnPosition;
    }
}
