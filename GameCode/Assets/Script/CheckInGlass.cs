using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInGlass : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Glass")
        {
            player.GetComponent<PlayerController>().inGlass = true;
            player.GetComponent<PlayerController>().doubleJump = true;
            //   player.GetComponent<PlayerController>().inGlass = true;        
        }
    }

    private void OnCollisionStay2D(Collision2D collision) // Cay cay cay cay cay cay cay cay cay cay cay cay cay .......................
    {
        if (collision.collider.tag == "Glass")
        {
            player.GetComponent<PlayerController>().inGlass = true;
            player.GetComponent<PlayerController>().doubleJump = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Glass")
        {
            player.GetComponent<PlayerController>().inGlass = false;
        }
    }

}
