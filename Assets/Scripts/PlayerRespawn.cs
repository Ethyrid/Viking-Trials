using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPosition;

    void Start()
    {
        // Inicializar la posición de respawn en la posición inicial del jugador
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
            // Actualizar la posición de respawn
            respawnPosition = other.transform.position;
        }
    }

    public void Respawn()
    {
        // Reiniciar la posición del jugador a la posición de respawn
        transform.position = respawnPosition;
    }
}
