using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMouseInside : MonoBehaviour
{
   public PlayerController player;

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (player.gameOver == true){
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
