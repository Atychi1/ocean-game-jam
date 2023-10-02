using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

    public void Shoot ( ){

     firePoint.transform.LookAt(Input.mousePosition);

 

     int bulletCount = 10;
     float spread = 1;
     Quaternion newRot = firePoint.rotation;

 

     for (int i = 0; i < bulletCount; i++)
     {
          float addedOffset =  (i - (bulletCount / 2) * spread);

 

          // Then add "addedOffset" to whatever rotation axis the player must rotate on
          newRot = Quaternion.Euler(firePoint.transform.localEulerAngles.x,             
          firePoint.transform.localEulerAngles.y, 
          firePoint.transform.localEulerAngles.z + addedOffset);

 

          Instantiate(bulletPrefab, firePoint.position, newRot);
     }
}
}
