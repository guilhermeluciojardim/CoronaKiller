using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaMonster : MonoBehaviour
{

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }
public Material OriginalColor;

    // Update is called once per frame
    void Update()
    {
        OriginalColor = GetComponent<MeshRenderer>().material;
        LookatPlayer();
    }

    void LookatPlayer(){
       // transform.LookAt(target,Vector3.up);
    }
}
