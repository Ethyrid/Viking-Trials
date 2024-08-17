using UnityEngine;

public class TeleportableObject : InteractableObject
{
    public Transform teleportDestinationUp; // La posición de destino al subir
    public Transform teleportDestinationDown; // La posición de destino al bajar

    private bool isAtTop = false; // Para rastrear la posición actual del jugador

    public override void Interact()
    {
        base.Interact();
        TeleportPlayer();
    }

    private void TeleportPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            if (isAtTop)
            {
                // Teletransportar hacia abajo
                if (teleportDestinationDown != null)
                {
                    player.transform.position = teleportDestinationDown.position;
                    player.transform.rotation = teleportDestinationDown.rotation;
                    isAtTop = false;
                }
            }
            else
            {
                // Teletransportar hacia arriba
                if (teleportDestinationUp != null)
                {
                    player.transform.position = teleportDestinationUp.position;
                    player.transform.rotation = teleportDestinationUp.rotation;
                    isAtTop = true;
                }
            }
        }
    }
}
