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
    public GameObject cam6;
    public GameObject cam7;
    public GameObject cam8;
    public GameObject cam9;
    public GameObject cam10;
    public GameObject cam11;
    public GameObject cam12;
    public GameObject cam13;
    // Start is called before the first frame update
    void Start()
    {
        
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
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
        }
        //Set Camera 2 based on X and Z position
        if ((transform.position.x < 8f)&&(transform.position.x > -10f)&&(transform.position.z > 13f))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
        }
        //Set Camera 3 based on X and Z position
        if ((transform.position.x < -10f)&&(transform.position.z > 13f))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
        }
        //Set Camera 4 based on X and Z position
        if ((transform.position.x < -3f)&&(transform.position.z < 13f)&&(transform.position.z > 2.5f))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(true);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
        }
         //Set Camera 5 based on X and Z position
        if ((transform.position.x > -3f)&&(transform.position.z < 13f)&&(transform.position.z > 2.5f))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(true);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
        }
         //Set Camera 6 based on X and Z position
        if ((transform.position.x > -3f)&&(transform.position.z < 2.5f))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(true);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
        }
           //Set Camera 7 based on X and Z position
        if ((transform.position.x < 10f)&&(transform.position.x > -10f)&&(transform.position.z < 2.5f)&&(transform.position.z > -6f))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(true);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
        }
           //Set Camera 8 based on X and Z position
        if ((transform.position.x < -10f)&&(transform.position.z < 2.5f)&&(transform.position.z > -6f))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(true);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
        }
          //Set Camera 9 based on X and Z position in 2 places
        if (((transform.position.z < -10)&&(transform.position.x < -22f)&&(transform.position.x > -25f)) 
        ||
        ((transform.position.z > -25f)&&(transform.position.z < -22f)&&(transform.position.x < 0)))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(true);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
        }
           //Set Camera 10 based on X and Z position in 2 places
        if (((transform.position.z > -25f)&&(transform.position.z < -22f)&&(transform.position.x > 0))
        ||
        (transform.position.z < -10f)&&(transform.position.x > 20)&&(transform.position.x < 25))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(true);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(false);
        }
            //Set Camera 11 based on X and Z position in 2 places
        if ((transform.position.z > -22f)&&(transform.position.z < -7f)&&(transform.position.x>-20)&&(transform.position.x<-9))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(true);
            cam12.SetActive(false);
            cam13.SetActive(false);
        }
            //Set Camera 12 based on X and Z position in 2 places
        if ((transform.position.z > -22f)&&(transform.position.z < -7f)&&(transform.position.x>-9)&&(transform.position.x<3))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(true);
            cam13.SetActive(false);
        }
            //Set Camera 13 based on X and Z position in 2 places
        if ((transform.position.z > -22f)&&(transform.position.z < -7f)&&(transform.position.x<19)&&(transform.position.x>3))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
            cam9.SetActive(false);
            cam10.SetActive(false);
            cam11.SetActive(false);
            cam12.SetActive(false);
            cam13.SetActive(true);
        }
    }
}
