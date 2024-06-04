using UnityEngine;

public class ActivateCanvasOnTriggerCustom : MonoBehaviour
{
    public Canvas pressE;           // Canvas que se muestra cuando el jugador está en el Trigger
    public Canvas customSoldOut;    // Canvas que se muestra cuando se presiona la tecla E

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

        if (customSoldOut != null)
        {
            customSoldOut.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No customSoldOut Canvas assigned to the script.");
        }
    }

    void Update()
    {
        // Si el jugador está en el Trigger y se presiona la tecla E
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (customSoldOut != null && customSoldOut.gameObject.activeSelf)
            {
                // Desactiva customSoldOut y activa pressE
                customSoldOut.gameObject.SetActive(false);
                if (pressE != null)
                {
                    pressE.gameObject.SetActive(true);
                }
            }
            else if (customSoldOut != null && !customSoldOut.gameObject.activeSelf)
            {
                // Activa customSoldOut y desactiva pressE
                customSoldOut.gameObject.SetActive(true);
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
            if (pressE != null && (customSoldOut == null || !customSoldOut.gameObject.activeSelf))
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

            if (customSoldOut != null)
            {
                customSoldOut.gameObject.SetActive(false);
            }
        }
    }
}
