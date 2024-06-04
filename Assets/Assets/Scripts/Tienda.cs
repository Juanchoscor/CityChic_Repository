using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda: MonoBehaviour
{
[SerializeField] GameObject prefabObjetoTienda;
[SerializeField] int numeroMaximoObjetosTienda;
[SerializeField] PlantillaObjetos [] listaTienda;
private Objeto objeto;
private void Start()
{
for (int i = 0; i <= numeroMaximoObjetosTienda -1; i++)
{
GameObject tienda = GameObject. Instantiate (prefabObjetoTienda, Vector2.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("Tienda").transform);
int indice = Random.Range(0, listaTienda. Length);
objeto = tienda.GetComponent<Objeto>();
objeto.crearObjeto (listaTienda[indice]);
}
}
}