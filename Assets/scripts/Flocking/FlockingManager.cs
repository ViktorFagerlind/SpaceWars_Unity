using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlockingManager : MonoBehaviour
{
  public float      m_minVelocity       = 1;
  public float      m_maxVelocity       = 8;
  public int        m_flockSize         = 20;
  public float      m_centerWeight      = 1;
  public float      m_velocityWeight    = 1;
  public float      m_separationWeight  = 1;
  public float      m_followWeight      = 1;
  public float      m_randomizeWeight   = 1;
  public Boid       m_prefab;
  public Transform  m_target;
  public List<Boid> m_boids = new List<Boid> ();  
  
  private Vector3   m_flockCenter;
  private Vector3   m_flockVelocity;
  
  public Vector3 flockCenter
  {
    get { return m_flockCenter;  }
    set { m_flockCenter = value; }
  }
  
  public Vector3 flockVelocity
  {
    get { return m_flockVelocity;  }
    set { m_flockVelocity = value; }
  }
  
  // Use this for initialization
  void Start ()
  {
    for (int i = 0; i < m_flockSize; i++) 
    {
      Boid boid = Instantiate (m_prefab, transform.position, transform.rotation) as Boid;
      boid.transform.parent = transform;
      boid.transform.localPosition = new Vector3 (Random.value * collider.bounds.size.x,
                                                  Random.value * collider.bounds.size.y,
                                                  Random.value * collider.bounds.size.z) - collider.bounds.extents;
      
      boid.setFlockingManager (this);
      m_boids.Add (boid);
    }
  }
 
  // Update is called once per frame
  void Update ()
  {
    Vector3 center = Vector3.zero;
    Vector3 velocity = Vector3.zero;
    
    foreach (Boid boid in m_boids) 
    {
      center   += boid.transform.localPosition;
      velocity += boid.rigidbody.velocity;
    }
    
    m_flockCenter   = center   / m_flockSize;
    m_flockVelocity = velocity / m_flockSize;
  }
}
