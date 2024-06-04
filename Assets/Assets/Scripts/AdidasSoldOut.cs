using UnityEngine;

public class ActivateCanvasOnTriggerAdidas : MonoBehaviour
{
    public Canvas pressE;           // Canvas que se muestra cuando el jugador está en el Trigger
    public Canvas adidasSoldOut;    // Canvas que se muestra cuando se presiona la tecla E

    private bool playerInTrigger = false;  // Bandera para verificar si el jugador está en el Trigger

    void Start()
    {
        // Asegúrate de que todos los Canvas estén desactivados al inicio
        if (pressE != null)
        {
            pressE.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No pressE Canvas assigned to the script.");
        }

        if (adidasSoldOut != null)
        {
            adidasSoldOut.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No adidasSoldOut Canvas assigned to the script.");
        }
    }

    void Update()
    {
        // Si el jugador está en el Trigger y se presiona la tecla E
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (adidasSoldOut != null && adidasSoldOut.gameObject.activeSelf)
            {
                // Desactiva adidasSoldOut y activa pressE
                adidasSoldOut.gameObject.SetActive(false);
                if (pressE != null)
                {
                    pressE.gameObject.SetActive(true);
                }
            }
            else if (adidasSoldOut != null && !adidasSoldOut.gameObject.activeSelf)
            {
                // Activa adidasSoldOut y desactiva pressE
                adidasSoldOut.gameObject.SetActive(true);
                if (pressE != null)
                {
                    pressE.gameObject.SetActive(false);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el Trigger es el personaje
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;  // El jugador está en el Trigger

            // Activa el Canvas pressE si el jugador está en el Trigger
            if (pressE != null && (adidasSoldOut == null || !adidasSoldOut.gameObject.activeSelf))
            {
                pressE.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Cuando el personaje salga del Trigger
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;  // El jugador salió del Trigger

            // Desactiva todos los Canvas al salir
            if (pressE != null)
            {
                pressE.gameObject.SetActive(false);
            }

            if (adidasSoldOut != null)
            {
                adidasSoldOut.gameObject.SetActive(false);
            }
        }
    }
}
