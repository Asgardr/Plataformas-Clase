using UnityEngine;

public class TriggerLoadAdditive : MonoBehaviour
{
    // TODO 1 - Añadir variable pública con el color de la puerta (tipo GameManager.DoorColor)
    [SerializeField] private GameManager.DoorColor _doorColor;

    /// <summary>
    /// La comprobación del tipo de gameobject que entra en el trigger se hace por tag
    /// El valor del tag que nos interesa se guarda en esta variable
    /// </summary>
    private const string m_PlayerTag = "Player";
    private GameManager m_GameManager = null;

    private void Start()
    {
        m_GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    /// <summary>
    /// Detecta cuándo un GameObject entra en el trigger al cual está asignado este componente.
    /// En nuestro caso, realizamos la carga aditiva del nivel indicado en el atributo
    /// público "LevelToLoadName"
    /// </summary>
    void OnTriggerEnter(Collider other)
	{
		LoadLevelAdditive(other.gameObject);
	}


    // TODO 2 - Hacer función que cargue un nivel de forma aditiva.
    // Será necesario pasarle el gameObject que ha colisionado con el trigger
    // Tras cargar el nivel, desactivamos el trigger
    private void LoadLevelAdditive(GameObject go)
    {
        if (go.CompareTag("Player"))
        {
            m_GameManager.TriggerLoadAdditive(_doorColor);

            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}