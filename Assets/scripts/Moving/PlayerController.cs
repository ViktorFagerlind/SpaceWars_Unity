using UnityEngine;
using System.Collections;

public class PlayerController : MovingRigidBody 
{
  // ------------------------------------------------------------------------------------------------------------------------------------------
  
  void Start () 
	{
	}
	
  // ------------------------------------------------------------------------------------------------------------------------------------------
  
  void FixedUpdate () 
	{
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));

    //print ("Fixed speed: " + rigidbody.velocity.magnitude);

    Move (mousePosition + new Vector3 (0,0,8));

    Stabilize (Vector3.forward);

    Lean ();
	}

  // ------------------------------------------------------------------------------------------------------------------------------------------
  
  void Update () 
  {

  }

  // ------------------------------------------------------------------------------------------------------------------------------------------
  
  void LateUpdate () 
  {
    //print ("Late speed: " + rigidbody.velocity.magnitude);
  }
}
