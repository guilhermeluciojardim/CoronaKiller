using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaMonster : MonoBehaviour
{
    public int Health = 12;
    public float speed = 3.0f;
    public float angrySpeed = 8.0f;

    public bool isAngry = false;
    public bool isLooking = true;
    public GameObject target;
    public ParticleSystem explosionParticle;

    public AudioSource monsterAngryNoise;
    public AudioSource monsterNormalNoise;


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
        monsterNormalNoise.Stop();
        monsterAngryNoise.loop = true;
        monsterAngryNoise.Play();
        Vector3 r = Random.insideUnitCircle;  
        r.Set(r.x, 0, r.y);
        transform.LookAt(target.transform,Vector3.up);

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
           explosionParticle.Play();
           monsterNormalNoise.Stop();
           monsterAngryNoise.Stop();
           gameObject.GetComponent<MeshRenderer>().enabled = false;
           StartCoroutine(WaitParticles()); 
            
        }
    }
void OnTriggerEnter(Collider other){
    if (other.tag == "Player"){
        isLooking = false;
    }
}
IEnumerator WaitParticles()
{
    yield return new WaitForSeconds(1f);
    Destroy(gameObject);
} 



}
