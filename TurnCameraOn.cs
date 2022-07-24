using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCameraOn : MonoBehaviour
{
    public GameObject[] cams;
    public GameObject ship;

    public GameObject axis;

    private float shipSpeed = 10f;
    private float rotateSpeed = 45f;

    public GameObject shipCam;

    private float posX;
    private float posY;
    private float posZ;

    private int cameraIndex;
    private bool ready = false;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        for (i=0; i < cams.Length; i++){
            cams[i].SetActive(false);
        }
        cameraIndex=0;
        cams[0].SetActive(true);
        
    }
public bool shipLanded = false;
public bool deploy = false;

public bool outOfShip = false;
//Entry animation for ship landing, deploy and setting of player
void BeginEntryAnimation(){
    if (!shipLanded && !deploy) {
        ship.transform.Translate(Vector3.down * shipSpeed * Time.deltaTime);
        shipCam.transform.Translate(Vector3.down * shipSpeed * Time.deltaTime);
        ship.transform.RotateAround(axis.transform.position,Vector3.down, rotateSpeed * Time.deltaTime);
        if (ship.transform.position.y < 16 && ship.transform.position.y > 7f){
            shipSpeed = 2f;
            shipCam.transform.Translate(Vector3.forward * shipSpeed * Time.deltaTime);
        }
        if (ship.transform.position.y < 7f){
            rotateSpeed=0;
            AudioSource audio = gameObject.AddComponent < AudioSource > ();
                audio.PlayOneShot ((AudioClip)Resources.Load ("Airlock"));
            deploy = true;    
        }
    }
    if (deploy && !outOfShip){
                StartCoroutine(WaitForSound()); 
        }
    if (outOfShip && !ready){
        transform.Translate(Vector3.forward * Time.deltaTime * 2f);
        shipCam.transform.Rotate(Vector3.right * Time.deltaTime * 8f);
        if (transform.position.z > 15f){
            ready=true;
            ship.transform.position = new Vector3(0,0,0);
            GetComponent<PlayerController>().enabled = !GetComponent<PlayerController>().enabled;
            ship.GetComponent<Rigidbody>().isKinematic = true;
        }

    }

}
// Function for waiting for the player to get out of the ship
 IEnumerator WaitForSound()
{
    transform.position = new Vector3(16.5f,7.85f,7.35f);
    AudioSource audio2 = gameObject.AddComponent < AudioSource > ();
                audio2.PlayOneShot ((AudioClip)Resources.Load ("Pop"));
    outOfShip = true;
    yield return new WaitForSeconds(4f);
    
} 
    // Update is called once per frame
    void Update()
    {
        posX=transform.position.x;
        posY=transform.position.y;
        posZ=transform.position.z;

    //Activate the game cameras after begining animation
    if (ready){

        //Start the first floor camera

        if (posY < 5){
        //Set Camera 1 based on X and Z position
        if ((posX > 8f)&&(posZ > 13f))
        {
            cameraIndex=1;
        }
        //Set Camera 2 based on X and Z position
        if ((posX < 8f)&&(posX > -10f)&&(posZ > 13f))
        {
            cameraIndex=2;
        }
        //Set Camera 3 based on X and Z position
        if ((posX < -10f)&&(posZ > 13f))
        {
            cameraIndex=3;
        }
        //Set Camera 4 based on X and Z position
        if ((posX < -3f)&&(posZ < 13f)&&(posZ > 2.5f))
        {
            cameraIndex=4;
        }
         //Set Camera 5 based on X and Z position
        if ((posX > -3f)&&(posZ < 13f)&&(posZ > 2.5f))
        {
            cameraIndex=5;
        }
         //Set Camera 6 based on X and Z position
        if ((posX > -3f)&&(posZ < 2.5f))
        {
            cameraIndex=6;
        }
           //Set Camera 7 based on X and Z position
        if ((posX < 10f)&&(posX > -10f)&&(posZ < 2.5f)&&(posZ > -6f))
        {
            cameraIndex=7;
        }
           //Set Camera 8 based on X and Z position
        if ((posX < -10f)&&(posZ < 2.5f)&&(posZ > -6f))
        {
            cameraIndex=8;
        }
          //Set Camera 9 based on X and Z position in 2 places
        if (((posZ < -10)&&(posX < -22f)&&(posX > -25f)) 
        ||
        ((posZ > -25f)&&(posZ < -22f)&&(posX < 0)))
        {
            cameraIndex=9;
        }
           //Set Camera 10 based on X and Z position in 2 places
        if (((posZ > -25f)&&(posZ < -22f)&&(posX > 0))
        ||
        (posZ < -10f)&&(posX > 20)&&(posX < 25))
        {
            cameraIndex=10;
        }
            //Set Camera 11 based on X and Z position in 2 places
        if ((posZ > -22f)&&(posZ < -7f)&&(posX>-20)&&(posX<-9))
        {
            cameraIndex=11;
        }
            //Set Camera 12 based on X and Z position in 2 places
        if ((posZ> -22f)&&(posZ < -7f)&&(posX > -9)&&(posX < 3))
        {
            cameraIndex=12;
        }
            //Set Camera 13 based on X and Z position in 2 places
        if ((posZ > -22f)&&(posZ < -7f)&&(posX < 19)&&(posX > 3))
        {
            cameraIndex=13;
        }
        }
        //Finish the first floor of cameras

        //Start the Second floor cameras
        if (posY > 5){
                if ((posX < 18) && (posX > 11) && (posZ >-21) && (posZ < -7)){
                    cameraIndex=14;
                }
                if ((posX<11) && (posX > 1) && (posZ >-21) && (posZ < -7)){
                    cameraIndex=15;
                }
                if ((posX < 1) && (posX > -17) && (posZ >-21) && (posZ < -7)){
                    cameraIndex=16;
                }
                if ((posX <-11) && (posZ >-21) && (posZ < -7)){
                    cameraIndex=17;
                }
                if ((posX < 5) && (posX>-20) && (posZ < 11) && (posZ > 2)){
                    cameraIndex=21;
                }

        }
        //Finish the second floor of cameras

        //Start the third floor of cameras
        if (posY > 10){
            if ((posZ >-21) && (posZ < -7) && (posX > -20) && (posX < 10) ){
                cameraIndex=18;
            }
            if ((posX > -20) && (posX < 10) && (posZ >-7)&& (posZ < 13)){
                cameraIndex=19;
            }
            if ((posX>10) && (posX < 25) && (posZ >-7)&& (posZ < 13)){
                cameraIndex=22;
            }
        }

        // Activate the camera according to cameraindex set in player position
        for (i=0; i < cams.Length; i++){
            if (cameraIndex == i){
                cams[i].SetActive(true);
            }
            else {
                cams[i].SetActive(false);
            }
        }
    }
    else {
        BeginEntryAnimation();
    }
    }
}
