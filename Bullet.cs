using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed, timer;
    public int damage;

    
    void Update()
    {
        transform.position+=transform.forward*speed*Time.deltaTime;
        
       
        

    }

    //function that destroy bullet after collision
   private void OnCollisionEnter(Collision collision)
    {  
   
        
       // if(timer>=4){
       GameObject.Destroy(gameObject);
       // }
    }
    
   /* private void OnTriggerEnter3D(Collider collider){
        Enemy enemy =  collider.GetComponent<Enemy>();
        if (enemy != null) {
            //Hit an Enemy
            enemy.Damage();
        }

    }*/

    //bullet diarection and speed->enemy
    public void InitBullet(Vector3 dir, float spd, int dmg)
    {    
        
        transform.forward=dir;
        speed=spd;
        damage=dmg;
    }
}
