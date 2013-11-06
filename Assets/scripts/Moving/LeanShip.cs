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
    float leanZ = Vector3.Dot (rigidbody.velocity, transform.right) * m_leanConst;
    print ("------");
    print ("" + rigidbody.velocity);
    print ("" + transform.right);
    print ("" + leanZ);
    print ("------");
    
    transform.localEulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -leanZ);
  }
}
