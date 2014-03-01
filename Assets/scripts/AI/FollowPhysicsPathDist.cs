using UnityEngine;
using System.Collections;

public class FollowPhysicsPathDist : MovingRigidBody
{
  public  string      m_pathName        = "";
  public  float       m_switchDistance  = 10;

  private int         m_currentIndex;
  private Vector3[]   m_path;
  private float       m_switchDistanceSqrd;

  // ------------------------------------------------------------------------------------------------------------------------------------------
  
  void Start ()
  {
    m_path = iTweenPath.GetPath (m_pathName);

    m_switchDistanceSqrd = m_switchDistance * m_switchDistance;
    m_currentIndex = 0;
  }
  
  // ------------------------------------------------------------------------------------------------------------------------------------------
  
  void Update ()
  {
    if ((m_path[m_currentIndex] - transform.position).sqrMagnitude < m_switchDistanceSqrd)
    {
      if (m_currentIndex == m_path.Length - 1)
      {
        Destroy (gameObject);
        return;
      }

      m_currentIndex++;
    }
  }

  // ------------------------------------------------------------------------------------------------------------------------------------------
  
  void FixedUpdate ()
  {
    Move (m_path[m_currentIndex]);
    
    Stabilize (rigidbody.velocity.normalized);
    
    Lean ();
  }
  
  // ------------------------------------------------------------------------------------------------------------------------------------------
  
}
