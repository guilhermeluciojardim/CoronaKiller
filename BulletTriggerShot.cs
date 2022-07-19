using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTriggerShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private Color original;
    private bool isColorChanged = false;
    void OnTriggerEnter(Collider other) {
    
         if (other.gameObject.CompareTag ("CoronaMonster")) 
         {           
             AudioSource audio = gameObject.AddComponent < AudioSource > ();
                audio.PlayOneShot ((AudioClip)Resources.Load ("Hit"));
            if (!isColorChanged){
                original = other.gameObject.GetComponent<MeshRenderer>().material.color;
            }
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            isColorChanged=true;
            StartCoroutine(WaitForColor(other,original));

            
         }
     }

       IEnumerator WaitForColor(Collider other, Color original)
{
    yield return new WaitForSeconds(0.01f); 
    other.gameObject.GetComponent<MeshRenderer>().material.color = original;
    isColorChanged = false;
    other.gameObject.SendMessage("HealthCheck", 1);
} 
}
