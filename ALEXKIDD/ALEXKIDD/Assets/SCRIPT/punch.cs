using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("StarBox"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Pedra"))
        {
            Destroy(collision.gameObject);
        }
       
    }

}
