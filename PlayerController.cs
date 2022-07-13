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

    public GameObject bulletPrefab;
    public GameObject pistol;
    public GameObject aug;
    public int pistolClip = 7;
    public int augClip = 25;
    public AudioSource OutOfBullets;
    public AudioSource Reload;
    public AudioSource ReloadFinish;
    private bool isReloading=false;
    private int CurrentWeapon = 1;
    private Vector3 WeaponPos;
    private Quaternion WeaponRotation;

    // Update is called once per frame
    void Update()
    {
        Movement();
        ChangeWeapon();
        FireBullet();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);
        transform.Rotate(Vector3.up, lookX * Time.deltaTime * turnSpeed);

        lookX = Input.GetAxis("Mouse X");
        lookY = Input.GetAxis("Mouse Y");
        if (Input.GetKey (KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * strafeSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * strafeSpeed);
        }
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
            if ((Input.GetKeyDown(KeyCode.Mouse1))&&(pistolClip!=7)){
                isReloading=true;
                Reload.Play();
                StartCoroutine(ReloadingPistol(2));
            }    
        }
        //Firing Aug
        else if (CurrentWeapon==2){
            if (Input.GetKeyDown(KeyCode.Mouse0)){
                if ((augClip > 0)&&(!isReloading)){
                    Instantiate(bulletPrefab,aug.transform.position,aug.transform.rotation);
                    augClip-=1;
                }
                else if(!isReloading){
                    OutOfBullets.Play();
                }
            }    
            if ((Input.GetKeyDown(KeyCode.Mouse1))&&(augClip!=25)){
                isReloading=true;
                Reload.Play();
                StartCoroutine(ReloadingAug(4));
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
