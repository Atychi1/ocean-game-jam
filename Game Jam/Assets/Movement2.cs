using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{

    public Rigidbody2D rb2D;
    static bool Space = true;
    public float moveSpeed = 0.1f;
    

        private void Update()
        {
            if (Input.GetKey("a"))
            {
                rb2D.AddForce(new Vector2(-moveSpeed, 0f));
                
            }

            if (Input.GetKey("d"))
            {
                rb2D.AddForce(new Vector2 (moveSpeed, 0f));
                
            }

		if (Input.GetKey("w"))
            {
                rb2D.AddForce(new Vector2 (0f, moveSpeed));
                
            }

		if (Input.GetKey("s"))
            {
                rb2D.AddForce(new Vector2 (0f, -moveSpeed));
               
            }

		if (Input.GetKeyDown("space") && Space)
	    {
		StartCoroutine(Dash());
		StartCoroutine(Cooldown());
  	    }

		
	}


	IEnumerator Dash()
	    {
		moveSpeed += 2f;
		yield return new WaitForSeconds(0.5f);
		moveSpeed -= 2f;
	    
 	    }

	IEnumerator Cooldown()
	{
	  Space = false;
	  yield return new WaitForSeconds(1.5f);
	  Space = true;
	}
}
