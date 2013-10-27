using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
  public  float       m_fireDeltaTime; 
  public  GameObject  m_shot;
  
  private float       m_lastShotTime; 
  
	// Use this for initialization
	void Start () 
  {
    m_lastShotTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () 
  {
    float currentTime = Time.realtimeSinceStartup;
    
    if (m_lastShotTime + m_fireDeltaTime < currentTime)
    {
      GameObject newShot;
      
      Quaternion newShotQuaternion = Quaternion.Euler (0, 0, transform.rotation.eulerAngles.z);
      
      newShot = Instantiate (m_shot,  transform.position, newShotQuaternion) as GameObject;
      
      newShot.rigidbody.velocity = newShot.transform.TransformDirection(Vector3.up * 100);
//      newShot.transform.rotation.Set (

      
      m_lastShotTime = currentTime;
    }
	}
}
