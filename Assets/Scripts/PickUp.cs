using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject crosshair1, crosshair2;
    public Transform objTransform, cameraTrans;
    public bool interactable, pickedup;
    public Rigidbody objRigidbody;
    public float throwAmount;
    public bool isThrowing;
    public float pickupRange = 2f; // Rango de distancia para recoger el objeto

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            SetCrosshair(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            SetCrosshair(false);
            interactable = false;
        }
    }

    void Update()
    {
        // Verificar si el objeto es interactuable y el jugador hace clic izquierdo
        if (interactable && Input.GetMouseButtonDown(0) && !pickedup)
        {
            // Usar un Raycast para verificar si el jugador está apuntando al objeto
            Ray ray = new Ray(cameraTrans.position, cameraTrans.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, pickupRange) && hit.transform == objTransform)
            {
                PickUpObject();
            }
        }
        else if (pickedup && Input.GetMouseButtonDown(0))
        {
            DropObject();
        }
        else if (pickedup && Input.GetMouseButtonDown(1))
        {
            ThrowObject();
        }

        // Asegurarse de que el objeto siga la cámara cuando está recogido
        if (pickedup)
        {
            objTransform.position = cameraTrans.position + cameraTrans.forward * 2; // Ajusta la distancia según tus necesidades
        }
    }

    void PickUpObject()
    {
        objTransform.parent = cameraTrans;
        objRigidbody.useGravity = false;
        objRigidbody.isKinematic = true;
        pickedup = true;
        isThrowing = false;
    }

    void DropObject()
    {
        objTransform.parent = null;
        objRigidbody.useGravity = true;
        objRigidbody.isKinematic = false;
        pickedup = false;
        isThrowing = false;
    }

    void ThrowObject()
    {
        objTransform.parent = null;
        objRigidbody.useGravity = true;
        objRigidbody.isKinematic = false;
        objRigidbody.AddForce(cameraTrans.forward * throwAmount, ForceMode.VelocityChange);
        pickedup = false;
        isThrowing = true;
    }

    void SetCrosshair(bool isInteractable)
    {
        crosshair1.SetActive(!isInteractable);
        crosshair2.SetActive(isInteractable);
    }
}
