using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaMonster : MonoBehaviour
{
    public int Health = 5;
    public float speed = 3.0f;
    public float angrySpeed = 5.0f;

    public bool isAngry = false;
    public bool isLooking = true;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (isLooking){
            LookForPlayer();
        }
        else if (isAngry){
            AngryMovement();
        }
        else{
            NormalMovement();
        }
    }

private int steps = 500;
    void LookForPlayer(){
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        steps-=1;
        if (steps == 0){
            transform.Rotate(0,180,0);
            steps=500;
        }
    }

    void NormalMovement(){
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    void AngryMovement(){
        //get a random direction
        Vector3 r = Random.insideUnitCircle;  
        r.Set(r.x, 0, r.y);

        transform.position =
            Vector3.MoveTowards(transform.position, transform.position + r, angrySpeed * Time.deltaTime);
        transform.position =
            Vector3.MoveTowards(transform.position, target.transform.position, angrySpeed * Time.deltaTime);
    }
    

// Public Method for decreasing health and kill the monster
    public void HealthCheck(int damage){
        Health--;
        isLooking=false;
        isAngry=true;
        if (Health < 1){
            Destroy(gameObject);
        }
    }
void OnTriggerEnter(Collider other){
    if (other.tag == "Player"){
        isLooking = false;
    }
}

}
