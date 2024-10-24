using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CutSceneTravel : MonoBehaviour
{
    public Camera m_Camera;
    public Transform m_Target;
    public float m_TravelTime;
    public float m_TimeCameraStop;

    private Camera m_MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        m_Camera.gameObject.SetActive(false);
        m_MainCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Travel());
        }
    }

    IEnumerator Travel()
    {
        Vector3 direction = Vector3.zero;
        Vector3 initialPosition = m_Camera.transform.position;
        //## TODO 1 Desactivamos la cámara principal y activamos la camara del travel.
        m_Camera.gameObject.SetActive (true);
        m_MainCamera.gameObject.SetActive(false);
        float time = 0;
        do
        {
            //## TODO 2 Hasta que no lleguemos a la distancia mínima, movemos la cámara a la velocidad necesaria para que la transición tarde m_TravelTime segundos.
            time += Time.deltaTime;
            m_Camera.transform.position = Vector3.Lerp(initialPosition, m_Target.position, time/m_TravelTime);
            yield return new WaitForEndOfFrame();
        }
        while (time < m_TravelTime);
        //TODO 3 esperamos un tiempo para volver a la normalidad.
        yield return new WaitForSeconds(m_TimeCameraStop);
        //TODO 4 reseteamos las cámaras para dejarlo todo como estaba.
        m_MainCamera.gameObject.SetActive(true);
        Destroy(gameObject);
    }

}
