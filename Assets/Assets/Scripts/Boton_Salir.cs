using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public string Sample_Scene = "SampleScene";

    public void CambiarAEscenaDestino()
    {
        SceneManager.LoadScene(Sample_Scene);
    }
}