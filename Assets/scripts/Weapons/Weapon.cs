using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
  public  float       m_fireDeltaTime = 1f; 
  public  float       m_inheritSpeed  = 1f; 
  public  float       m_shotSpeed     = 100f; 
  public  GameObject  m_shot;
  
  private float       m_speedCalculationTime = 0.1f; 
  private float       m_lastShotTime; 
  private Vector3     m_speed; 
  private Vector3     m_previousPosition; 
  
	// Use this for initialization
	void Start () 
  {
    m_lastShotTime = Time.realtimeSinceStartup;

    m_speed = new Vector3 (0, 0, 0);
    m_previousPosition = gameObject.transform.position;
    InvokeRepeating ("SpeedCheck", m_speedCalculationTime, m_speedCalculationTime);
	}
	
  void SpeedCheck ()
  {
    m_speed = (gameObject.transform.position - m_previousPosition) / m_speedCalculationTime;
    
    m_previousPosition = gameObject.transform.position;
  }
  
	// Update is called once per frame
	void Update () 
  {
    float currentTime = Time.realtimeSinceStartup;
    
    if (m_lastShotTime + m_fireDeltaTime < currentTime)
    {
      GameObject newShot;
      Vector3    shotVelocity; 
      Quaternion shotRotation;
      
      shotVelocity = transform.forward * m_shotSpeed + m_inheritSpeed * m_speed;
      shotRotation = Quaternion.LookRotation (shotVelocity);
      
      newShot = Instantiate (m_shot, transform.position, shotRotation) as GameObject;
      
      newShot.layer               = gameObject.layer;
      newShot.rigidbody.velocity  = shotVelocity;
      
      m_lastShotTime = currentTime;
    }
	}
}
