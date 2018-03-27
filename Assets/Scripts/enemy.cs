using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {


    public int color;
    public bool isEnemyDead = false;
    private float transformZ;
 

    // Use this for initialization
    public Transform player;
    //At what distance will the enemy walk towards the player?
    public float walkingDistance = 1000.0f;
    //In what time will the enemy complete the journey between its position and the players position(Lesser the time, faster the speed)
    public float smoothTime = 10.0f;
    //Vector3 used to store the velocity of the enemy
    private Vector3 smoothVelocity = Vector3.zero;
    //Call every frame
    void Start() {
        
        transformZ = transform.position.z;

    }

    // Update is called once per frame
    void Update() {

        Movement();
      
    }

    void Movement()
    {
        //Look at the player
        transform.LookAt(player);
        //Calculate distance between player
        float distance = Vector3.Distance(transform.position, player.position);
        //If the distance is smaller than the walkingDistance
        if (distance < walkingDistance)
        {
            //Move the enemy towards the player with smoothdamp
            transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("collided");

        if (col.gameObject.name == "red" && color == 0)
        {
            isEnemyDead = true;
            Destroy(col.gameObject);
            this.gameObject.SetActive(false);
            Infinte();


        }
        else if (col.gameObject.name == "blue" && color == 1)
        {
            isEnemyDead = true;
            Destroy(col.gameObject);
            this.gameObject.SetActive(false);
            Infinte();
        }
        else if (col.gameObject.name == "green" && color == 2)
        {
            isEnemyDead = true;
            Destroy(col.gameObject);
            this.gameObject.SetActive(false);
            Infinte();

        }

       


    }
    void Infinte()
    {
        isEnemyDead = false;
        this.gameObject.SetActive(true);
        transform.position = new Vector3(Random.Range(-20,20), 2f, transformZ);
    }


}
   


