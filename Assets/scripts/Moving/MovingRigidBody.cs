using UnityEngine;
using System.Collections;

public class MovingRigidBody : MonoBehaviour 
{
  public float m_lean                 = 1.2f;
  
  public float m_stabilize_speed      = 20f;
  public float m_stabilize_stability  = 0.3f;

  public float m_move_dist_weight     = 250;
  public float m_move_max_force       = 10000;
  public float m_move_max_velocity    = 10000;

  private float m_move_max_velocity_sqrd = 10000;
  // ------------------------------------------------------------------------------------------------------------------------------------------
  
  void Start ()
  {
    m_move_max_velocity_sqrd = m_move_max_velocity * m_move_max_velocity;
  }

  // ------------------------------------------------------------------------------------------------------------------------------------------
  
  protected void Move (Vector3 to_position) 
  {
    Vector3 distance  = to_position - transform.position;
    Vector3 force     = m_move_dist_weight * distance;

    // Do not add force in the velocity direction if maximum speed is reached.
    if ((Vector3.Dot (rigidbody.velocity, force) > 0.0f) &&
        rigidbody.velocity.sqrMagnitude >= m_move_max_velocity_sqrd)
      return;

    if (force.sqrMagnitude > m_move_max_force * m_move_max_force)
    {
      //print ("capped: force = " + force + " dist = " + distance.magnitude + " limit = " + (m_move_max_force * m_move_max_force));
      force = force.normalized * m_move_max_force;
    }

    rigidbody.AddForce (force);
  }

  // ------------------------------------------------------------------------------------------------------------------------------------------
  
  protected void Stabilize (Vector3 desiredDirection)
  {
    Vector3 predictedUp = Quaternion.AngleAxis (
      rigidbody.angularVelocity.magnitude * Mathf.Rad2Deg * m_stabilize_stability / m_stabilize_speed,
            rigidbody.angularVelocity
        ) * transform.forward;
 
    Vector3 torqueVector = Vector3.Cross (predictedUp, desiredDirection);
    rigidbody.AddTorque (torqueVector * m_stabilize_speed * m_stabilize_speed);
  }

  // ------------------------------------------------------------------------------------------------------------------------------------------

  protected void Lean () 
  {
    float leanZ = Vector3.Dot (rigidbody.velocity, transform.right) * m_lean;

    transform.localEulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -leanZ);
  }

  // ------------------------------------------------------------------------------------------------------------------------------------------
  
}