using UnityEngine;
using System.Collections;

public class FollowTarget : MovingRigidBody
{
  public Transform m_target;

  // ------------------------------------------------------------------------------------------------------------------------------------------
  
  void Start ()
  {
    // Assume that player is the target if unassigned
    if (!m_target)
      m_target = GameObject.FindGameObjectWithTag ("Player").transform;
  }
  
  // ------------------------------------------------------------------------------------------------------------------------------------------
  
  void FixedUpdate ()
  {
    if (m_target)
      Move (m_target.position);
    
    Stabilize (rigidbody.velocity.normalized);
    
    Lean ();
  }

  // ------------------------------------------------------------------------------------------------------------------------------------------
  
}
