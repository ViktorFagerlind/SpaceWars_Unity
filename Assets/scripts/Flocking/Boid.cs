using UnityEngine;
using System.Collections;

public class Boid : MonoBehaviour
{
  private float           m_minVelocity;
  private float           m_minVelocitySqrd;
  private float           m_maxVelocity;
  private float           m_maxVelocitySqrd;
  private FlockingManager m_flockingManager;  
  
  public void initialise (FlockingManager flockingManager, Vector3 position, float minVelocity, float maxVelocity)
  {
    transform.position = position;
    
    m_minVelocity = Random.Range (minVelocity * 0.8f, minVelocity * 1.2f);
    m_maxVelocity = Random.Range (maxVelocity * 0.8f, maxVelocity * 1.2f);
    
    m_minVelocitySqrd = m_minVelocity * m_minVelocity;
    m_maxVelocitySqrd = m_maxVelocity * m_maxVelocity;
    
    rigidbody.velocity = Random.rotationUniform * Vector3.forward * Random.Range (minVelocity, maxVelocity);;
    rigidbody.velocity.Set (rigidbody.velocity.x, 0f, rigidbody.velocity.z);
    
    m_flockingManager = flockingManager;
  }
  
  void Update ()
  {
    if (m_flockingManager == null)
      return;
    
    float speedSqrd = rigidbody.velocity.sqrMagnitude;
    if (speedSqrd > m_maxVelocitySqrd) 
    {
      rigidbody.velocity = rigidbody.velocity.normalized * m_maxVelocity;
    } 
    else if (speedSqrd < m_minVelocitySqrd) 
    {
      rigidbody.velocity = rigidbody.velocity.normalized * m_minVelocity;
    }
    
    transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
    rigidbody.velocity.Set (rigidbody.velocity.x, 0f, rigidbody.velocity.z);
    
    transform.rotation = Quaternion.LookRotation (rigidbody.velocity);
  }
}


