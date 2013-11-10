using UnityEngine;
using System.Collections;

public class Boid : MonoBehaviour
{
  private FlockingManager m_flockingManager;  
  
  public void setFlockingManager (FlockingManager flockingManager)
  {
    m_flockingManager = flockingManager;
  }
  
  void Update ()
  {
    Vector3 relativePos = steer () * Time.deltaTime;
    //       rigidbody.velocity += relativePos; // This is what the Flocking scripts do
    rigidbody.velocity = steer () * Time.deltaTime; // Alternative  
    //       transform.position += steer() * Time.deltaTime; // This cause bumpy movements     
    transform.rotation = Quaternion.LookRotation (relativePos);
    
    // enforce minimum and maximum speeds for the boids
    float speed = rigidbody.velocity.magnitude;
    if (speed > m_flockingManager.m_maxVelocity) 
    {
      rigidbody.velocity = rigidbody.velocity.normalized * m_flockingManager.m_maxVelocity;
    } 
    else if (speed < m_flockingManager.m_minVelocity) 
    {
      rigidbody.velocity = rigidbody.velocity.normalized * m_flockingManager.m_minVelocity;
    }
  }
  
  Vector3 steer ()
  {
    Vector3 center      = m_flockingManager.flockCenter          - transform.localPosition;      // cohesion
    Vector3 velocity    = m_flockingManager.flockVelocity        - rigidbody.velocity;       // alignment
    Vector3 follow      = m_flockingManager.m_target.localPosition - transform.localPosition; // follow leader
    Vector3 separation  = Vector3.zero;                      // separation
    
    foreach (Boid boid in m_flockingManager.m_boids) 
    {
      if (boid != this) 
      {
        Vector3 relativePos = transform.localPosition - boid.transform.localPosition;
        separation += relativePos / (relativePos.sqrMagnitude);       
      }
    }
 
    // 3D space   
    Vector3 randomize = new Vector3 ((Random.value * 2) - 1, (Random.value * 2) - 1, (Random.value * 2) - 1);// randomize
 
    // 2D space
    // Vector3 randomize = new Vector3((Random.value * 2) - 1, 0, (Random.value * 2) - 1);   
 
    randomize.Normalize ();
 
    return (m_flockingManager.m_centerWeight       * center      + 
            m_flockingManager.m_velocityWeight     * velocity    + 
            m_flockingManager.m_separationWeight   * separation  + 
            m_flockingManager.m_followWeight       * follow      + 
            m_flockingManager.m_randomizeWeight    * randomize);
  }
  
}
