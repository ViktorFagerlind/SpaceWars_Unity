using UnityEngine;
using System.Collections;

public class FollowPhysicsPathTime : MovingRigidBody
{
  public  string      m_pathName;
  public  float       m_deltaTime = 1;

  private int         m_currentIndex;
  private float       m_previousTime;
  private Vector3[]   m_path;

  // ------------------------------------------------------------------------------------------------------------------------------------------
  
  void Start ()
  {
    m_currentIndex = 0;
    m_previousTime = Time.realtimeSinceStartup;

    m_path = iTweenPath.GetPath (m_pathName);
  }
  
  // ------------------------------------------------------------------------------------------------------------------------------------------
  
  void Update ()
  {
    float currentTime = Time.realtimeSinceStartup;

    if ((m_currentIndex < m_path.Length - 1) &&
        (m_previousTime + m_deltaTime < currentTime))
    {
      m_currentIndex++;
      m_previousTime = currentTime;
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
