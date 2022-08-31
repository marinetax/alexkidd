using UnityEngine;
using System.Collections;

public class PLAYER : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    private float eixy;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;

        eixy = transform.position.y;

    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        
          if (eixy >= player.transform.position.y)
        {
            transform.position = player.transform.position + offset;
            eixy = player.transform.position.y;
        }

        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
