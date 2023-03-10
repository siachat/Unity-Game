using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 200f;
    public float sidewaysForce = 3f;
   

    

    public GameObject hpBar;
    public int HPMax=100;
    public int HP;

    public GameObject myCam;
    public  GameObject startObject;
       
    
    // Start is called before the first frame update
    void Start()
    {
        //collision and take damage of player
      
startObject = GameObject.Find("GM");

        HP=HPMax;

        rb.useGravity = false;               
       rb.AddForce (0, 0, forwardForce*Time.deltaTime, ForceMode.VelocityChange);
       
    }






 // Update is called once per frame

    void FixedUpdate()
    {
        
        
        if (Input.GetKey("d")) {
            //rb.AddForce(0, 0, sidewaysForce*Time.deltaTime, ForceMode.VelocityChange);
            rb.AddForce(Vector3.right*sidewaysForce*Time.deltaTime, ForceMode.Impulse);
        }

        if (Input.GetKey("a") && (transform.position.x > -3f)) {
            rb.AddForce(Vector3.left*sidewaysForce*Time.deltaTime, ForceMode.Impulse);
        }
         if (rb.position.x > 8f) FindObjectOfType<GM>().EndGame();
        if (rb.position.x <-8f) FindObjectOfType<GM>().EndGame();


       

    }



 private void OnCollisionEnter(Collision collision){
           
        
    if (collision.gameObject.tag=="Bullet") {
        
        TakeDamage(collision.gameObject.GetComponent<Bullet>().damage);
       
    }

    else if (collision.gameObject.tag=="PickUp") {
        
        powerUp ps = collision.gameObject.GetComponent<powerUp>();

        if (ps.pickup == PickupTypes.HEALTH && HP<HPMax){
            TakeDamage(-(int)ps.myValue);
            Destroy(collision.gameObject);
        }
       
    }
    
}





//How damege got
public void TakeDamage (int damage)
{
    HP-=damage;

    //lifebar
    Vector3 newScale= hpBar.transform.localScale;
    newScale.x=HP / (float)HPMax;
    hpBar.transform.localScale=newScale;
    if (HP<=0){  
        myCam.transform.parent=transform.parent;
        Destroy(gameObject);
     }
    if(HP>HPMax){
        HP=HPMax;}

}




}
