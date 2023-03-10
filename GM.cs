using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
   public GameObject resetBtn;
   public GameObject resetBtn2;
    //public GameObject gameOverimage;
   // public GameObject levelCompletedimage;
    public Rigidbody playerRb;
    public Rigidbody stopplayerrb;
    
        
    // Start is called before the first frame update
     void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        
         
   
    }    

    public void EndGame() 
    {
	    
        resetBtn.SetActive(true);
         Rigidbody.Destroy(playerRb);
          //Destroy(playerRb);
       // playerRb.isKinematic=true;
        //gameOverimage.SetActive(true);
      //   Scene scene = SceneManager.GetActiveScene();
     //SceneManager.LoadScene(scene.name);
     
   
        
    }
    
    

    public void EndLevel() 
    {   resetBtn2.SetActive(true);
      
       
       // levelCompletedimage.SetActive(true);           
    }
    
   public void ResetGame()
    {  
     //stopplayerrb.AddForce (0, 0, 300f*Time.deltaTime, ForceMode.VelocityChange);
     Scene scene = SceneManager.GetActiveScene();
     SceneManager.LoadScene(scene.name);
      Debug.Log("reset");
    }

}
