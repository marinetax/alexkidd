using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXIT : MonoBehaviour {

    //GameExit
    public void SalirJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

}
