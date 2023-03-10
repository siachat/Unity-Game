using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PickupTypes{HEALTH /*, SPEEDBOOST*/}

public class powerUp : MonoBehaviour
{   
    public PickupTypes pickup;

    public float myValue;
    public float rotAngle=20;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotAngle=Time.deltaTime,0), Space.Self);
    }
}
