using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fplayer : MonoBehaviour
{
    
    public Transform player;
    public Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3 (0f, 2f, -5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;        
    }
}