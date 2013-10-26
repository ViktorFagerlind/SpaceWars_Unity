using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
  public float m_moveDistConst;
  public float m_moveCapForce;
  
  public float m_leanConst;
  
  
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called before physics
	void FixedUpdate () 
	{
    //------------ Get mouse position-------------------
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 100));
    
    //------------ Handle position ---------------------
    Vector3 distance  = mousePosition - transform.position;
    Vector3 force     = m_moveDistConst * distance;
    
    if (force.sqrMagnitude > m_moveCapForce * m_moveCapForce)
    {
      force.Normalize ();
      force = m_moveCapForce * force;
    }
    
    rigidbody.AddForce (force);
    
//    print ("mousePosition: "  + mousePosition);
//    print ("force: "          + force);
//    print ("distance: "       + distance);
	}
  
  
  // Update is called once per frame
  void Update () 
  {
    Vector3 rightForVehicle = new Vector3 (1, 0, 0);
    rightForVehicle = Quaternion.AngleAxis (transform.rotation.z, Vector3.forward) * rightForVehicle;
    
    float leanY = Vector3.Dot (rigidbody.velocity, rightForVehicle) * m_leanConst;
    
    transform.localEulerAngles = new Vector3(transform.rotation.eulerAngles.x, leanY, transform.rotation.eulerAngles.z);
  }
}
