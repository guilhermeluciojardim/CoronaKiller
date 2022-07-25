using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health: " + health;
        pistolText.text = "Pistol: " + pistolClip;
        augText.text = "AUG: " + augClip;
    }
    public TextMeshProUGUI healthText;

    public TextMeshProUGUI pistolText;
    public TextMeshProUGUI augText;

    public TextMeshProUGUI gameoverText;
    public Button restartButton;

    
    private float speed = 5f;
    private float strafeSpeed = 5f;
    private float turnSpeed = 450f;
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
    public AudioSource JumpSound;

    public AudioSource Grunt1;
    public AudioSource Grunt2;
    private bool isReloading=false;
    private int CurrentWeapon = 1;
    private Vector3 WeaponPos;
    private Quaternion WeaponRotation;

    private bool gameOver = false;

    BoxCollider playerBox;

    // Update is called once per frame
    void Update()
    {
        if (!gameOver){
            Movement();
            Jump();
            KeepStanding();
            ChangeWeapon();
            FireBullet();
            UpdateHealthText();
            UpdateBulletsText();
        }
        else{
            UpdateGameOverText();
        }
    }

    void UpdateHealthText(){
        healthText.text = "Health: " + health;
    }
    void UpdateBulletsText(){
        if (isReloading && CurrentWeapon==1){
            pistolText.text = "Pistol: Reloading...";    
        }
        else if (isReloading && CurrentWeapon==2){
            augText.text = "AUG: Reloading...";    
        }
        else {
        pistolText.text = "Pistol: " + pistolClip;
        augText.text = "AUG: " + augClip;
        }    
    }
    void UpdateGameOverText(){
        gameoverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
//Function to keep the player from falling

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }
private float fallMultiplier = 3.5f;
private float lowJumpMultiplier = 2f;
private float jumpVelocity = 8f;
Rigidbody rb;
private bool isJumpAvailable = true;

public int health = 100;


    void Jump(){
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isJumpAvailable ){
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
            JumpSound.Play();
            isJumpAvailable = false;
            StartCoroutine(WaitForJumpAgain(1));
        }
        //Increasing gravity velocity for better falling
        if (rb.velocity.y < 0){
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space)){
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        } 
    }
// Prevent Player from falling
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
    }
    //Function for movement using W A S D keys and Mouse for look
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
       // Move left foot
        if ((ZStep<5)&&(rightfoot)&&(Count==25)){
            ZStep = 5;
            rightfoot=false;
            leftfoot=true;
            if (isJumpAvailable){Step1.Play();}
            Count=0;
            return ZStep;
        }
        //Move right foot
        else if ((ZStep >-5)&&(leftfoot)&&(Count==25)){
            ZStep=-5;
            rightfoot=true;
            leftfoot=false;
            if (isJumpAvailable){Step2.Play();}
            Count=0;
            return ZStep;
            }
            return 0;
        }
//Function for change weapon on pressing TAB
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

    // Function for fire bullets, control number of bullets in clip and Reload with left and right mouse click
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
            //Reloading Pistol
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
            // Reloading Aug
            if ((Input.GetKeyDown(KeyCode.Mouse1))&&(augClip!=25)&&(!isReloading)){
                isReloading=true;
                ReloadSlower.Play();
                StartCoroutine(ReloadingAug(8));
            }
        }
    }

// function for check if the player collides with corona monster and loses health
void OnCollisionEnter(Collision collider){
    if (!gameOver){
        if (collider.gameObject.CompareTag("CoronaMonster")){
            health -= 1;
            Grunt1.Play();
            collider.gameObject.transform.Translate(Vector3.back * Time.deltaTime);
        }
        if (health < 0) {
            gameOver=true;
            Grunt2.Play();
            Vector3 rot = new Vector3(90,0,0);
            transform.Rotate(rot * Time.deltaTime);
            explosionParticle.Play();
        }
    }
}
public ParticleSystem explosionParticle;

//Function for wait X seconds for finish reload pistol
IEnumerator ReloadingPistol(int reloadtime)  //  <-  its a standalone method
{
    pistol.transform.Rotate(20,0,0);
    yield return new WaitForSeconds(reloadtime);
    ReloadFinish.Play();
    pistolClip=7;  
    isReloading=false;
    pistol.transform.Rotate(-20,0,0);

}
//Function for wait X seconds for finish reload AUG
IEnumerator ReloadingAug(int reloadtime)  //  <-  its a standalone method
{
    aug.transform.Rotate(-80,0,0);
    yield return new WaitForSeconds(reloadtime);
    ReloadFinish.Play();
    augClip=25;  
    isReloading=false;
    aug.transform.Rotate(80,0,0);

}
//Function for wait for jump again
  IEnumerator WaitForJumpAgain(int reloadtime)  //  <-  its a standalone method
{
    yield return new WaitForSeconds(reloadtime); 
    isJumpAvailable = true;
} 
}
