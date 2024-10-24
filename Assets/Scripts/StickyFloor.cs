using UnityEngine;
using System.Collections;

public class StickyFloor : MonoBehaviour {

    private Transform m_originalParent = null;
    public Transform m_transformToAttach;

    void Start()
    {
        if (m_transformToAttach == null)
            m_transformToAttach = transform;
    }

    void OnTriggerEnter(Collider other)
    {
        //TODO 1: Cuando el objeto que caiga sea attachable, atachamos el objeto.
        Atachable atachable = other.GetComponent<Atachable>();
        if(atachable.IsAtachable && atachable != null) 
        {
            m_originalParent = other.transform.parent;
            other.gameObject.transform.SetParent(m_transformToAttach, true);
            atachable.IsAtached = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        MovingPlatform movingPlatform = gameObject.GetComponent<MovingPlatform>();
        //TODO 2: Cuando el objeto que caiga sea attachable, como estamos saliendo, desatachamos el objeto. Ojo, la scala puede cambiar!!!
        Atachable atachable = other.GetComponent<Atachable>();
        if (atachable.IsAtached && atachable != null)
        {
            other.transform.SetParent(m_originalParent, true);
            m_originalParent = null;
            atachable.IsAtached = false;

            //Ejercicio 2
            Vector3 direction = movingPlatform.GetDirection();
            other.gameObject.GetComponent<Rigidbody>().AddForce(direction * movingPlatform.m_MovementSpeed, ForceMode.Impulse);
        }
    }
}
