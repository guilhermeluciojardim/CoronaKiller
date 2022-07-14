using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private float speed = 5f;
    private float strafeSpeed = 5f;
    private float turnSpeed = 200f;
    private float horizontalInput;
    private float forwardInput;
    private float lookX;
    private float lookY;

    private float ZStep=0;
     bool rightfoot=true;
    bool leftfoot=false;


    public GameObject bulletPrefab;
    public GameObject bulletAugPrefab;
    public GameObject pistol;
    public GameObject aug;
    public int pistolClip = 7;
    public int augClip = 25;
    public AudioSource OutOfBullets;
    public AudioSource Reload;
    public AudioSource ReloadFinish;
    public AudioSource ReloadSlower;
    public AudioSource Step1;
    public AudioSource Step2;
    private bool isReloading=false;
    private int CurrentWeapon = 1;
    private Vector3 WeaponPos;
    private Quaternion WeaponRotation;

    // Update is called once per frame
    void Update()
    {
        Movement();
        KeepStanding();
        ChangeWeapon();
        FireBullet();
    }
//Function to keep the player from falling

    void KeepStanding(){
        float lockpos=0;
        float x = transform.rotation.eulerAngles.x;
        float y = transform.rotation.eulerAngles.y;
        float z = transform.rotation.eulerAngles.z;
        if ((z > 10.0f)||(z < -10.0f)){
            transform.rotation = Quaternion.Euler (x,y,lockpos);
        }
        if ((x > 10.0f)||(x < -10.0f)){
            transform.rotation = Quaternion.Euler (lockpos,y,z);
        }

        //transform.rotation = Quaternion.Euler (lockPos, lockPos, lockPos);
    }
    //Function for movement using W A S D keys
    void Movement()
    {
        if (Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.Rotate(0,0,AnimatedSteps());
        }
        if (Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.back * Time.deltaTime * speed);
            transform.Rotate(0,0,AnimatedSteps());
        }
        if (Input.GetKey (KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * strafeSpeed);
            transform.Rotate(0,0,AnimatedSteps());
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * strafeSpeed);
            transform.Rotate(0,0,AnimatedSteps());
            
        }
        lookX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, lookX * Time.deltaTime * turnSpeed);
    }
// Function to animate steps from walking
    int Count=0;
    float AnimatedSteps(){
       Count+=1;
        if ((ZStep<5)&&(rightfoot)&&(Count==25)){
            ZStep = 5;
            rightfoot=false;
            leftfoot=true;
            Step1.Play();
            Count=0;
            return ZStep;
        }
        else if ((ZStep >-5)&&(leftfoot)&&(Count==25)){
            ZStep=-5;
            rightfoot=true;
            leftfoot=false;
            Step2.Play();
            Count=0;
            return ZStep;
            }
            return 0;
        }

    void ChangeWeapon(){
        if ((Input.GetKeyDown(KeyCode.Tab))&&(!isReloading)){
            if (CurrentWeapon==1){
                CurrentWeapon=2;
                //Change weapon position
                WeaponPos=pistol.transform.position; 
                pistol.transform.position = aug.transform.position; 
                aug.transform.position=WeaponPos; 
                //Change weapon Rotation
                pistol.transform.Rotate(90,90,0);
                aug.transform.Rotate(0,-90,90);
                Reload.Play();
            }
            else if (CurrentWeapon==2){
                CurrentWeapon=1;
               //Change weapon position
                WeaponPos=aug.transform.position; 
                aug.transform.position = pistol.transform.position; 
                pistol.transform.position = WeaponPos; 
                //Chgange weapon rotation
                pistol.transform.Rotate(0,-90,90);
                aug.transform.Rotate(90,180,90);
                Reload.Play();

                }
        }
    }

    // Function for fire bullets and control number of bullets in clip
    void FireBullet(){
        // Firing Pistol
        if (CurrentWeapon==1){ 
            if (Input.GetKeyDown(KeyCode.Mouse0)){
                if ((pistolClip > 0)&&(!isReloading)){
                    Instantiate(bulletPrefab,pistol.transform.position,pistol.transform.rotation);
                    pistolClip-=1;
                }
                else if(!isReloading){
                    OutOfBullets.Play();
                }
            }
            if ((Input.GetKeyDown(KeyCode.Mouse1))&&(pistolClip!=7)&&(!isReloading)){
                isReloading=true;
                Reload.Play();
                StartCoroutine(ReloadingPistol(3));
            }    
        }
        //Firing Aug
        else if (CurrentWeapon==2){
            if (Input.GetKeyDown(KeyCode.Mouse0)){
                if ((augClip > 0)&&(!isReloading)){
                    Instantiate(bulletAugPrefab,aug.transform.position,aug.transform.rotation);
                    augClip-=1;
                }
                else if(!isReloading){
                    OutOfBullets.Play();
                }
            }    
            if ((Input.GetKeyDown(KeyCode.Mouse1))&&(augClip!=25)&&(!isReloading)){
                isReloading=true;
                ReloadSlower.Play();
                StartCoroutine(ReloadingAug(8));
            }
        }
    }

//Function for wait X seconds for finish reload
IEnumerator ReloadingPistol(int reloadtime)  //  <-  its a standalone method
{
    yield return new WaitForSeconds(reloadtime);
    ReloadFinish.Play();
    pistolClip=7;  
    isReloading=false;

}

IEnumerator ReloadingAug(int reloadtime)  //  <-  its a standalone method
{
    yield return new WaitForSeconds(reloadtime);
    ReloadFinish.Play();
    augClip=25;  
    isReloading=false;

}
   
}
