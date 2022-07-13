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

    private float posX;
    private float posY;
    private float posZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posX=transform.position.x;
        posY=transform.position.y;
        posZ=transform.position.z;
        //Set Camera 1 based on X and Z position
        if ((posX > 8f)&&(posZ > 13f))
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
        if ((posX < 8f)&&(posX > -10f)&&(posZ > 13f))
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
        if ((posX < -10f)&&(posZ > 13f))
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
        if ((posX < -3f)&&(posZ < 13f)&&(posZ > 2.5f))
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
        if ((posX > -3f)&&(posZ < 13f)&&(posZ > 2.5f))
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
        if ((posX > -3f)&&(posZ < 2.5f))
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
        if ((posX < 10f)&&(posX > -10f)&&(posZ < 2.5f)&&(posZ > -6f))
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
        if ((posX < -10f)&&(posZ < 2.5f)&&(posZ > -6f))
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
        if (((posZ < -10)&&(posX < -22f)&&(posX > -25f)) 
        ||
        ((posZ > -25f)&&(posZ < -22f)&&(posX < 0)))
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
        if (((posZ > -25f)&&(posZ < -22f)&&(posX > 0))
        ||
        (posZ < -10f)&&(posX > 20)&&(posX < 25))
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
        if ((posZ > -22f)&&(posZ < -7f)&&(posX>-20)&&(posX<-9))
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
        if ((posZ> -22f)&&(posZ < -7f)&&(posX > -9)&&(posX < 3))
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
        if ((posZ > -22f)&&(posZ < -7f)&&(posX < 19)&&(posX > 3))
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
