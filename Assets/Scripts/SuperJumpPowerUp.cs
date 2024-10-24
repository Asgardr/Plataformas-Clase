using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class SuperJumpPowerUp : MonoBehaviour
{
    /// <summary>
    /// Atributo que indica el tiempo que durará el powerUp
    /// </summary>
    public float m_duration;
    /// <summary>
    /// Atributo que indica la altura máxima de salto que alcanzará
    /// el jugador cuando el power up esté activo
    /// </summary>
    public float m_SuperJumpHeight = 4.0f;

    /// <summary>
    /// Cuando el jugador toca el ítem, este debe otorgar la habilidad de super-salto al jugador
    /// durante un tiempo determinado
    /// </summary>
    /// <param name="other">
    /// Objeto que chica contra el item <see cref="Collider"/>
    /// </param>
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //TrailRenderer trailRenderer = other.GetComponent<TrailRenderer>();
            // TODO 1 - Le envío un mensaje "SetJumpHeight" con la altura que tengo configurada para el super-salto
            //ThirdPersonCharacter characterController = other.GetComponent<ThirdPersonCharacter>();
            //characterController.SetJumpHeight(m_SuperJumpHeight);
            // TODO 2 - Desactivo el renderer y el collider de mi gameObject
            // Pista: atributo "enabled"
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            // TODO Refactor 1 - Iniciar el timer del GUIManager (método StartPowerUpTimer)
            //GUIManager.Instance.StartPowerUpTimer(m_duration);
            // TODO Refactor 2 - Obtener el componente TrailRenderer del jugador y activarlo
            //trailRenderer.enabled = true;

            yield return new WaitForSeconds(m_duration);

            // TODO 3 - Envío un mensaje recuperando la altura del salto anterior
            //characterController.RestoreJumpHeight();

            // TODO Refactor 3 - Obtener el componente TrailRenderer del jugador y desactivarlo
            //trailRenderer.enabled = false;

            Destroy(gameObject);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PowerUpController>().ActivarPowerUp(m_SuperJumpHeight, m_duration);
            //TrailRenderer trailRenderer = other.GetComponent<TrailRenderer>();
            // TODO 1 - Le envío un mensaje "SetJumpHeight" con la altura que tengo configurada para el super-salto
            //ThirdPersonCharacter characterController = other.GetComponent<ThirdPersonCharacter>();
            //characterController.SetJumpHeight(m_SuperJumpHeight);
            // TODO 2 - Desactivo el renderer y el collider de mi gameObject
            // Pista: atributo "enabled"
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            // TODO Refactor 1 - Iniciar el timer del GUIManager (método StartPowerUpTimer)
            //GUIManager.Instance.StartPowerUpTimer(m_duration);
            // TODO Refactor 2 - Obtener el componente TrailRenderer del jugador y activarlo
            //trailRenderer.enabled = true;

            //yield return new WaitForSeconds(m_duration);

            // TODO 3 - Envío un mensaje recuperando la altura del salto anterior
            //characterController.RestoreJumpHeight();

            // TODO Refactor 3 - Obtener el componente TrailRenderer del jugador y desactivarlo
            //trailRenderer.enabled = false;

            Destroy(gameObject);
        }
    }
}