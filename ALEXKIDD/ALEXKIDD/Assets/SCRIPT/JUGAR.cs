using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JUGAR : MonoBehaviour {

    //NuevaPartida
    public void CargarPartidaNueva()
    {
        SceneManager.LoadScene("principal");
    }
}