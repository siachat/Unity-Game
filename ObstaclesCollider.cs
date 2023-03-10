using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCollider : MonoBehaviour
{
     public PlayerMovement movement;

    private void OnCollisionEnter(Collision other) {

        if (other.collider.tag == "Obstacle") {


            movement.enabled = false;
            FindObjectOfType<GM>().EndGame();
        }
        
    }
}
