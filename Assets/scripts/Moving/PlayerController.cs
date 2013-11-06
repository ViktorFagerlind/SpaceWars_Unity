using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
  public float m_moveDistConst = 400;
  public float m_moveCapForce  = 5000;
  
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called before physics
	void FixedUpdate () 
	{
    //------------ Get mouse position-------------------
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    
    //------------ Handle position ---------------------
    Vector3 distance  = mousePosition - transform.position;
    Vector3 force     = m_moveDistConst * distance;
    
    if (force.sqrMagnitude > m_moveCapForce * m_moveCapForce)
    {
      force.Normalize ();
      force = m_moveCapForce * force;
    }
    
    rigidbody.AddForce (force);
	}
  
  
  // Update is called once per frame
  void Update () 
  {
  }
}
