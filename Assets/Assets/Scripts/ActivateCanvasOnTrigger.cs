using UnityEngine;
using UnityEngine.UI;

public class ActivateCanvasOnTrigger : MonoBehaviour
{
    public Canvas jordanProduct;            // Canvas del producto Jordan
    public Canvas pressE;                   // Canvas que se muestra cuando se presiona la tecla E
    public Canvas jordanSizes;              // Canvas de selección de tallas
    public Canvas jordanCart;               // Canvas del carrito
    public Canvas jordanPay;                // Canvas de pago
    public Button sizeFromProduct;          // Botón para cambiar al Canvas de selección de tallas desde el producto
    public Button backToProductFromSize;    // Botón para volver al Canvas del producto desde la selección de tallas
    public Button cartFromProduct;          // Botón en Canvas del producto para cambiar al Canvas del carrito
    public Button cartFromSizes;            // Botón en Canvas de selección de tallas para cambiar al Canvas del carrito (opción 1)
    public Button cartFromSizes2;           // Botón en Canvas de selección de tallas para cambiar al Canvas del carrito (opción 2)
    public Button closeCart;                // Botón para cerrar el carrito y volver al producto
    public Button cartToPay;                // Botón para ir del carrito al Canvas de pago

    private bool playerInTrigger = false;   // Bandera para verificar si el jugador está en el Trigger

    void Start()
    {
        // Asegúrate de que todos los Canvas estén desactivados al inicio
        if (jordanProduct != null)
            jordanProduct.gameObject.SetActive(false);
        else
            Debug.LogWarning("No Canvas assigned to the script.");

        if (pressE != null)
            pressE.gameObject.SetActive(false);
        else
            Debug.LogWarning("No pressE Canvas assigned to the script.");

        if (jordanSizes != null)
            jordanSizes.gameObject.SetActive(false);
        else
            Debug.LogWarning("No jordanSizes Canvas assigned to the script.");

        if (jordanCart != null)
            jordanCart.gameObject.SetActive(false);
        else
            Debug.LogWarning("No jordanCart Canvas assigned to the script.");

        if (jordanPay != null)
            jordanPay.gameObject.SetActive(false);
        else
            Debug.LogWarning("No jordanPay Canvas assigned to the script.");

        if (sizeFromProduct != null)
        {
            sizeFromProduct.gameObject.SetActive(false);
            sizeFromProduct.onClick.AddListener(SwitchToJordanSizes);
        }
        else
            Debug.LogWarning("No sizeFromProduct button assigned to the script.");

        if (backToProductFromSize != null)
        {
            backToProductFromSize.gameObject.SetActive(false);
            backToProductFromSize.onClick.AddListener(SwitchToJordanProduct);
        }
        else
            Debug.LogWarning("No backToProductFromSize button assigned to the script.");

        if (cartFromProduct != null)
            cartFromProduct.onClick.AddListener(SwitchToJordanCart);
        else
            Debug.LogWarning("No cartFromProduct button assigned to the script.");

        if (cartFromSizes != null)
            cartFromSizes.onClick.AddListener(SwitchToJordanCart);
        else
            Debug.LogWarning("No cartFromSizes button assigned to the script.");

        if (cartFromSizes2 != null)
            cartFromSizes2.onClick.AddListener(SwitchToJordanCart);
        else
            Debug.LogWarning("No cartFromSizes2 button assigned to the script.");

        if (closeCart != null)
            closeCart.onClick.AddListener(CloseJordanCart);
        else
            Debug.LogWarning("No closeCart button assigned to the script.");

        if (cartToPay != null)
            cartToPay.onClick.AddListener(SwitchToJordanPay);
        else
            Debug.LogWarning("No cartToPay button assigned to the script.");
    }

    void Update()
    {
        // Si el jugador está en el Trigger y se presiona la tecla E
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            // Alterna el estado del Canvas del producto Jordan (activa/desactiva)
            if (jordanProduct != null)
            {
                jordanProduct.gameObject.SetActive(!jordanProduct.gameObject.activeSelf);

                // Si el Canvas del producto Jordan se activa, desactiva los otros Canvas
                if (jordanProduct.gameObject.activeSelf)
                {
                    if (pressE != null)
                        pressE.gameObject.SetActive(false);

                    if (jordanSizes != null)
                        jordanSizes.gameObject.SetActive(false);

                    if (jordanCart != null)
                        jordanCart.gameObject.SetActive(false);

                    if (jordanPay != null)
                        jordanPay.gameObject.SetActive(false);

                    // Muestra el botón de tamaño
                    if (sizeFromProduct != null)
                        sizeFromProduct.gameObject.SetActive(true);
                }
                else
                {
                    // Oculta el botón de tamaño si el Canvas del producto Jordan se desactiva
                    if (sizeFromProduct != null)
                        sizeFromProduct.gameObject.SetActive(false);
                }
            }
        }

        // Activa el Canvas de presionar E si el jugador está en el Trigger y los otros Canvas están desactivados
        if (playerInTrigger && (jordanProduct == null || !jordanProduct.gameObject.activeSelf) && (jordanSizes == null || !jordanSizes.gameObject.activeSelf) && (jordanCart == null || !jordanCart.gameObject.activeSelf) && (jordanPay == null || !jordanPay.gameObject.activeSelf))
        {
            if (pressE != null)
                pressE.gameObject.SetActive(true);
        }
        else
        {
            if (pressE != null)
                pressE.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el Trigger es el personaje
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;  // El jugador está en el Trigger
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Cuando el personaje salga del Trigger
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;  // El jugador salió del Trigger
            // Desactiva todos los Canvas al salir
            if (jordanProduct != null)
                jordanProduct.gameObject.SetActive(false);

            if (pressE != null)
                pressE.gameObject.SetActive(false);

            if (jordanSizes != null)
                jordanSizes.gameObject.SetActive(false);

            if (jordanCart != null)
                jordanCart.gameObject.SetActive(false);

            if (jordanPay != null)
                jordanPay.gameObject.SetActive(false);

            // Oculta los botones
            if (sizeFromProduct != null)
                sizeFromProduct.gameObject.SetActive(false);

            if (backToProductFromSize != null)
                backToProductFromSize.gameObject.SetActive(false);

            if (cartFromSizes != null)
                cartFromSizes.gameObject.SetActive(false);

            if (cartFromSizes2 != null)
                cartFromSizes2.gameObject.SetActive(false);

            if (closeCart != null)
                closeCart.gameObject.SetActive(false);

            if (cartToPay != null)
                cartToPay.gameObject.SetActive(false);
        }
    }

    void SwitchToJordanSizes()
    {
        // Desactiva todos los demás Canvas
        if (jordanProduct != null)
            jordanProduct.gameObject.SetActive(false);

        if (pressE != null)
            pressE.gameObject.SetActive(false);

        if (jordanCart != null)
            jordanCart.gameObject.SetActive(false);

        if (jordanPay != null)
            jordanPay.gameObject.SetActive(false);

        // Activa el jordanSizes
        if (jordanSizes != null)
            jordanSizes.gameObject.SetActive(true);

        // Oculta el sizeFromProduct
        if (sizeFromProduct != null)
            sizeFromProduct.gameObject.SetActive(false);

        // Muestra el backToProductFromSize
        if (backToProductFromSize != null)
            backToProductFromSize.gameObject.SetActive(true);
    }

    void SwitchToJordanProduct()
    {
        // Desactiva todos los demás Canvas
        if (jordanSizes != null)
            jordanSizes.gameObject.SetActive(false);

        if (pressE != null)
            pressE.gameObject.SetActive(false);

        if (jordanCart != null)
            jordanCart.gameObject.SetActive(false);

        if (jordanPay != null)
            jordanPay.gameObject.SetActive(false);

        // Activa el jordanProduct
        if (jordanProduct != null)
            jordanProduct.gameObject.SetActive(true);

        // Oculta el backToProductFromSize
        if (backToProductFromSize != null)
            backToProductFromSize.gameObject.SetActive(false);

        // Muestra el sizeFromProduct
        if (sizeFromProduct != null)
            sizeFromProduct.gameObject.SetActive(true);
    }

    void SwitchToJordanCart()
    {
        // Desactiva todos los demás Canvas
        if (jordanProduct != null)
            jordanProduct.gameObject.SetActive(false);

        if (pressE != null)
            pressE.gameObject.SetActive(false);

        if (jordanSizes != null)
            jordanSizes.gameObject.SetActive(false);

        if (jordanPay != null)
            jordanPay.gameObject.SetActive(false);

        // Activa el jordanCart
        if (jordanCart != null)
            jordanCart.gameObject.SetActive(true);
    }

    void CloseJordanCart()
    {
        // Desactiva el Canvas del carrito y activa el del producto
        if (jordanCart != null)
            jordanCart.gameObject.SetActive(false);

        if (jordanProduct != null)
            jordanProduct.gameObject.SetActive(true);

        // Oculta el botón de cerrar carrito y muestra el botón de tamaño
        if (closeCart != null)
            closeCart.gameObject.SetActive(false);

        if (sizeFromProduct != null)
            sizeFromProduct.gameObject.SetActive(true);
    }

    void SwitchToJordanPay()
    {
        // Desactiva el Canvas del carrito y activa el de pago
        if (jordanCart != null)
            jordanCart.gameObject.SetActive(false);

        if (jordanPay != null)
            jordanPay.gameObject.SetActive(true);
    }
}
