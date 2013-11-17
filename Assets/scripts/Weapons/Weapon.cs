using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
  public  float       m_fireDeltaTime = 1f; 
  public  float       m_inheritSpeed  = 1f; 
  public  float       m_shotSpeed     = 100f; 
  public  GameObject  m_shot;
  
  private float       m_speedCalculationTime = 0.1f; 
  private Vector3     m_speed; 
  private Vector3     m_previousPosition; 
  
  private float       m_lastShotTime; 
  
  
	// Use this for initialization
	void Start () 
  {
    m_speed = new Vector3 (0, 0, 0);
    m_previousPosition = gameObject.transform.position;
    
    // Use repeating function for speed check if there is no rigid body
    if (m_inheritSpeed != 0f && rigidbody == null)
      InvokeRepeating ("SpeedCheck", m_speedCalculationTime, m_speedCalculationTime);
    
    m_lastShotTime = Time.realtimeSinceStartup + Random.Range (0f, m_fireDeltaTime);
	}
	
  void SpeedCheck ()
  {
    m_speed = (gameObject.transform.position - m_previousPosition) / m_speedCalculationTime;
    
    m_previousPosition = gameObject.transform.position;
  }
  
  public bool IsTimeToShoot ()
  {
    float currentTime = Time.realtimeSinceStartup;
    
    return m_lastShotTime + m_fireDeltaTime < currentTime;
  }
  
  public void Shoot ()
  {
    GameObject newShot;
    Vector3    shotVelocity; 
    Quaternion shotRotation;
    
    // Use rigid body for speed if it exists
    if (rigidbody != null)
      m_speed = rigidbody.velocity;
    
    shotVelocity = transform.forward * m_shotSpeed + m_inheritSpeed * m_speed;
    shotRotation = Quaternion.LookRotation (shotVelocity);
    
    newShot = Instantiate (m_shot, transform.position, shotRotation) as GameObject;
    
    newShot.layer               = gameObject.layer;
    newShot.rigidbody.velocity  = shotVelocity;
    
    m_lastShotTime = Time.realtimeSinceStartup;
  }
}
