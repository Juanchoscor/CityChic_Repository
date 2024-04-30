using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Objeto : MonoBehaviour
{
    [SerializeField] Image imagenObjeto;
    [SerializeField] TextMeshProUGUI textoObjeto;
    [SerializeField] TextMeshProUGUI precioObjeeto;
    public void crearObjeto (PlantillaObjetos datosObjeto)
    {
        imagenObjeto.sprite = datosObjeto.imagenObjeto;
        textoObjeto.text = datosObjeto.textoObjeto;
        precioObjeeto.text = datosObjeto.precioObjeto.ToString();
    }

}
