using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public AudioClip interactionSound; // El sonido de la interacción
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = interactionSound;
    }

    public void PlaySound()
    {
        if (audioSource != null && interactionSound != null)
        {
            audioSource.Play();
        }
    }

    public virtual void Interact()
    {
        PlaySound();
    }
}
