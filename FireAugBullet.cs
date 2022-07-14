using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAugBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(90,0,0);
    }
public float speed=200f;
    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
