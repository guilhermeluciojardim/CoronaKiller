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
    private float strafeSpeed = 2f;
    private float turnSpeed = 200f;
    private float horizontalInput;
    private float forwardInput;
    private float lookX;
    private float lookY;

    public GameObject bulletPrefab;
    public GameObject pistol;
    public GameObject aug;
    public int pistolClip = 7;

    public AudioSource OutOfBullets;
    public AudioSource Reload;
    public AudioSource ReloadFinish;
    private bool isReloading=false;

    // Update is called once per frame
    void Update()
    {
        Movement();
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

    // Function for fire bullets and control number of bullets in clip
    void FireBullet(){
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
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
                StartCoroutine(ReloadingPistol());
        }
    }

//Function for wait 2 seconds for finish reload
IEnumerator ReloadingPistol()  //  <-  its a standalone method
{
    yield return new WaitForSeconds(2);
    ReloadFinish.Play();
    pistolClip=7;  
    isReloading=false;

}
   
}
