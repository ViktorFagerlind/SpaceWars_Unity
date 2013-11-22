using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlockingManager : MonoBehaviour
{
  public float      m_zoneRadius        = 100f;
  public float      m_highThresh        = 50f;
  public float      m_lowThresh         = 10f;
  public int        m_flockSize         = 20;
  public Boid       m_prefab;
  public float      m_minVelocity       = 1f;
  public float      m_maxVelocity       = 8f;
  
  public Vector3    m_flockCenter;
  public float      m_predatorDistance  = 2f;
  public float      m_predatorForce     = 8f;
  
  public float      m_forceCenter       = 1f;
  public float      m_forceRepel        = 10f;
  public float      m_forceMatchSpeed   = 10f;
  public float      m_forceAttract      = 10f;

  private float     m_zoneRadiusSqrd;
  private float     m_predatorDistanceSqrd;
  
  private Transform m_predator;
  private Boid[]    m_boids;
  
  // Use this for initialization
  void Start ()
  {
    m_zoneRadiusSqrd       = m_zoneRadius * m_zoneRadius;
    m_predatorDistanceSqrd = m_predatorDistance * m_predatorDistance;
    
    m_boids = new Boid[m_flockSize];
    
    for (int i = 0; i < m_flockSize; i++) 
    {
      Boid boid = Instantiate (m_prefab, transform.position, transform.rotation) as Boid;
      Vector3 boidPosition = collider.transform.position + 
                                new Vector3 (Random.value * collider.bounds.size.x,
                                             0f,
                                             Random.value * collider.bounds.size.z) - 
                                new Vector3 (Random.value * collider.bounds.extents.x,
                                             0f,
                                             Random.value * collider.bounds.extents.z);
      
      boid.initialise (this, boidPosition, m_minVelocity, m_maxVelocity);
      m_boids[i] = boid;
    }
    
    m_predator = GameObject.FindGameObjectWithTag ("Player").transform;
    
    
    StartCoroutine (ControlBoids());
  }
 
  // Update is called once per frame
  IEnumerator ControlBoids () // Update ()
  {
    while (true)
    {
      for (int i1=0; i1 < m_flockSize; i1++)
      {
        int i2 = i1 + 1;
        
        Boid b1 = m_boids[i1];
        
        // Handle a potential dead boid
        if (b1 == null)
          continue;
        
        // Add center gravity
        Vector3 centerGravity = (m_flockCenter - b1.transform.position).normalized * m_forceCenter;
        b1.rigidbody.AddForce (centerGravity, ForceMode.Acceleration);

        // Handle predator avoidance
        if (m_predator != null)
        {
          Vector3 dir      = b1.transform.position - m_predator.transform.position;
          float   distSqrd = dir.sqrMagnitude;
          
          if (distSqrd < m_predatorDistanceSqrd)
          {
            float F = (m_predatorDistanceSqrd / distSqrd - 1.0f) * m_predatorForce;
            
            b1.rigidbody.AddForce (dir.normalized * F, ForceMode.Acceleration);
          }
        }
        
        for (; i2 < m_flockSize; i2++) 
        {
          Boid b2 = m_boids[i2];
          
          // Handle a potential dead boid
          if (b2 == null)
            continue;
          
          Vector3 dir      = b1.transform.position - b2.transform.position;
          float   distSqrd = dir.sqrMagnitude;
  
          if (distSqrd < m_zoneRadiusSqrd) 
          { 
            Vector3 b1BaseForce;
            Vector3 b2BaseForce;
          
            // If the neighbor is within the zone radius...
            float percent = distSqrd / m_zoneRadiusSqrd;
       
            if (percent < m_lowThresh) 
            { 
              // ... and is within the lower threshold limits, separate...
              float F = (m_lowThresh / percent - 1.0f) * m_forceRepel;
              dir = dir.normalized * F;
              b1BaseForce = dir;
              b2BaseForce = -dir;
            } 
            else if (percent < m_highThresh) 
            { 
              // ... else if it is within the higher threshold limits, align...
              float threshDelta = m_highThresh - m_lowThresh;
              float adjustedPercent = (percent - m_lowThresh) / threshDelta;
              float F = (0.5f - Mathf.Cos (adjustedPercent * Mathf.PI * 2.0f) * 0.5f + 0.5f) * m_forceMatchSpeed;
              b1BaseForce = b2.rigidbody.velocity.normalized * F;
              b2BaseForce = b2.rigidbody.velocity.normalized * F;
            } 
            else
            { 
              // ... else, attract.
              float threshDelta = 1.0f - m_highThresh;
              float adjustedPercent = (percent - m_highThresh) / threshDelta;
              float F = (0.5f - Mathf.Cos (adjustedPercent * Mathf.PI * 2.0f) * 0.5f + 0.5f) * m_forceAttract;
              dir = dir.normalized * F;
              b1BaseForce = -dir;
              b2BaseForce = dir;
            }
            
            //print (b2BaseForce * m_force);
            b2BaseForce.Set (b2BaseForce.x, 0f, b2BaseForce.z);
            b1BaseForce.Set (b1BaseForce.x, 0f, b1BaseForce.z);
            
            
            b2.rigidbody.AddForce (b2BaseForce, ForceMode.Acceleration);
            b1.rigidbody.AddForce (b1BaseForce, ForceMode.Acceleration);
          }
        }
      }
      
      yield return 0;
    } // while 
  } // ControlBoids
}

