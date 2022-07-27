using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovePlayerMenu : MonoBehaviour
{
 public GameObject pistol;
 private bool firstShot = false;

 float speed = 1.0f;
 float amount = 1.0f;

 public Button restartButton;
 
void Start(){
    StartCoroutine(WaitForNextShoot());
}

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 2.5){
            transform.Translate(Vector3.right * 20f * Time.deltaTime);
                
        }
        else {
            transform.Rotate(Vector3.down, 50f * Time.deltaTime);
        }
    }
    IEnumerator WaitForNextShoot(){
        yield return new WaitForSeconds(1);
        pistol.GetComponent<ParticleSystem>().Play();
            AudioSource audio = gameObject.AddComponent < AudioSource > ();
            audio.PlayOneShot ((AudioClip)Resources.Load ("PistolFire"));                
    }

    public void StartGame(){
        SceneManager.LoadScene("Game");
        
    }

}
