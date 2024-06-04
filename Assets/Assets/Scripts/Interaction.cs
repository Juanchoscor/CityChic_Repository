using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interaccion : MonoBehaviour


{
    // Start is called before the first frame update
    public GameObject presionar_e;
  public GameObject press_s;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay()
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        SceneManager.LoadScene("Jordan_Product");
      
      }
      if (Input.GetKeyDown(KeyCode.S))
      {
        SceneManager.LoadScene("SampleScene");

      }
        presionar_e.SetActive(true);
    }
    void OnTriggerExit()
    {
        presionar_e.SetActive(false);
    }
}
