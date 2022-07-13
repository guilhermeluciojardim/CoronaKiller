using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyBullet());
    }
    IEnumerator DestroyBullet()  //  <-  its a standalone method
{
    yield return new WaitForSeconds(2);
    Destroy(gameObject);
}
}
