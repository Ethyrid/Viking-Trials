using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] grassSteps; // Array de clips de pasos en césped
    public AudioClip[] woodSteps; // Array de clips de pasos en madera
    public AudioClip[] stoneSteps; // Array de clips de pasos en piedra
    public float stepInterval = 0.5f; // Intervalo de tiempo entre pasos

    private AudioSource audioSource;
    private Rigidbody rb;
    private float stepTimer;
    private string currentSurface;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on " + gameObject.name);
        }
    }

    void Update()
    {
        if (rb != null && IsGrounded() && rb.velocity.magnitude > 2f)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        UpdateSurfaceTag(collision.collider.tag);
    }

    void OnCollisionStay(Collision collision)
    {
        UpdateSurfaceTag(collision.collider.tag);
    }

    void UpdateSurfaceTag(string tag)
    {
        if (tag == "Grass" || tag == "Wood" || tag == "Stone")
        {
            currentSurface = tag;
        }
    }

    void PlayFootstep()
    {
        AudioClip clip = null;

        switch (currentSurface)
        {
            case "Grass":
                clip = grassSteps[Random.Range(0, grassSteps.Length)];
                break;
            case "Wood":
                clip = woodSteps[Random.Range(0, woodSteps.Length)];
                break;
            case "Stone":
                clip = stoneSteps[Random.Range(0, stoneSteps.Length)];
                break;
        }

        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    bool IsGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(ray, 1.1f);
    }
}