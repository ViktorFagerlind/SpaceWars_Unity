using UnityEngine;
using System.Collections;

public class LeanShip : MonoBehaviour 
{
  public float m_leanConst     = 0.5f;

	// Use this for initialization
	void Start () 
  {
	
	}
	
	// Update is called once per frame
	void Update () 
  {
    Vector3 rightForVehicle = new Vector3 (1, 0, 0);
    rightForVehicle = Quaternion.AngleAxis (transform.rotation.z, Vector3.forward) * rightForVehicle;
    
    float leanY = Vector3.Dot (rigidbody.velocity, rightForVehicle) * m_leanConst;
    
    transform.localEulerAngles = new Vector3(transform.rotation.eulerAngles.x, -leanY, transform.rotation.eulerAngles.z);
  }
}
