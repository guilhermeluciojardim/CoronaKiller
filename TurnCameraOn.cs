using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCameraOn : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject cam5;
    // Start is called before the first frame update
    void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);
        cam5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Set Camera 1 based on X and Z position
        if ((transform.position.x > 8f)&&(transform.position.z > 13f))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
        }
        //Set Camera 2 based on X and Z position
        if ((transform.position.x < 8f)&&(transform.position.x > -10f)&&(transform.position.z > 13f))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
        }
        //Set Camera 3 based on X and Z position
        if ((transform.position.x < -10f)&&(transform.position.z > 13f))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
            cam4.SetActive(false);
            cam5.SetActive(false);
        }
        //Set Camera 4 based on X and Z position
        if ((transform.position.x < -3f)&&(transform.position.z < 13f)&&(transform.position.z > 2.5f))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(true);
            cam5.SetActive(false);
        }
         //Set Camera 5 based on X and Z position
        if ((transform.position.x > -3f)&&(transform.position.z < 13f)&&(transform.position.z > 2.5f))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(true);
        }
    }
}
