using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{    

    public GameObject bulletSpawner;
    public GameObject bullet;

    public int gunDamage;
    public float bulletSpeed;
    public float firingDelay=0.133f;
    public float firingDelayLeft = 0;



////////////////////////////////////////////////////////
public List<GunStruct> guns = new List<GunStruct >();
public int myGun = 0;
public MeshRenderer myGunRender;
public float timeSinceLastShot;
public float weaponSwitchDelay=0.3f;
public float timeSinceLastWeaponSwitch;

//////////////////////////////////damager/////////////////////////////////

void Start()
    {
        myGunRender.material.color = guns [myGun].gunMat;
    }

    //HP=hit points
/*
    public GameObject hpBar;
    public int HPMax=100;
    public int HP;

    void Start()
    {
        HP=HPMax;
    }

private void OnCollisionEnter(Collision collision){
    if (collision.gameObject.tag=="Bullet") {
        TakeDamage(collision.gameObject.GetComponent<Bullet>().damage);
    }
}

//How damege got
public void TakeDamage (int damage)
{
    HP-=damage;

    //lifebar
    Vector3 newScale= hpBar.transform.localScale;
    newScale.x=HP/ (float)HPMax;
    hpBar.transform.localScale=newScale;

    if (HP<=0){   }
    if(HP>HPMax){HP=HPMax;}



}*/

//////////////////////////////

    public void Damage(){}


 void FixedUpdate()
    {

 /////////////////////////////////////////////////////////////////////////
 timeSinceLastShot+=Time.deltaTime;
 timeSinceLastWeaponSwitch+=Time.deltaTime;

///////////////////////////////////////////////////////////////////////


        firingDelayLeft-=Time.deltaTime;
         //rb.AddForce(0, 0, sidewaysForce*Time.deltaTime, ForceMode.VelocityChange);

       // if(firingDelayLeft<=0){
     // if (Input.GetMouseButton(0))
     // {
        if(timeSinceLastShot>guns[myGun].delay){
            // RaycastHit hit;
            // if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)){   
           FireBullet();
           
          // }
     
        
        }
    

     // }
   }

public void FireBullet(){

    List<Vector3> shots = new List <Vector3>();
    if(guns[myGun].firingPattern==FiringPattern.SINGLE)
    {
        shots.Add(transform.forward);
    }
    else if(guns[myGun].firingPattern==FiringPattern.SPREAD)
    {
        
        for(int i=0; i*2<guns[myGun].shots; i++)
        {
            Vector3 posV=Quaternion.AngleAxis(guns[myGun].spread*i,transform.up)*transform.forward;
            shots.Add(posV);
            if(i !=0)
            {
                Vector3 negV=Quaternion.AngleAxis(-guns[myGun].spread*i,transform.up)*transform.forward;
                shots.Add(negV);
            }
            
        }

    }
    else if (guns[myGun].firingPattern==FiringPattern.SHOTGUN){
        for(int i=0; i<guns[myGun].shots;i++)
        {
            
            Vector2 scatter = Random.insideUnitCircle;
            Vector3 dir=transform.forward.normalized / Mathf.Tan(guns[myGun].spread*Mathf.PI / 180);
            dir +=transform.up.normalized *scatter.y;
            dir += transform.right.normalized*scatter.x;
            dir.Normalize();
            shots.Add(dir);
        }
    }

    for(int i=0; i<shots.Count; i++){
    GameObject b = Instantiate(bullet, bulletSpawner.transform.position, Quaternion.identity);
            //Methodos InitBullet from Bullets script
    b.GetComponent<Bullet>().InitBullet(bulletSpawner.transform.forward, guns[myGun].speed, guns[myGun].damage);
    }
           timeSinceLastShot=0;
}




}



[System.Serializable]
public struct GunStruct 
{
   public string name;
   public int damage;
   public int speed;
   public float delay;
   public FiringPattern firingPattern;
   public int shots;
   public float spread;
   public Color gunMat;
}

public enum FiringPattern{SINGLE,SPREAD, SHOTGUN}