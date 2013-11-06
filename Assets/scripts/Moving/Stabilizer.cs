using UnityEngine;
using System.Collections;

public class Stabilizer : MonoBehaviour
{
  public float m_stability = 0.3f;
  public float m_speed     = 2.0f;
 
  // Update is called once per frame
  void FixedUpdate ()
  {
    Vector3 predictedUp = Quaternion.AngleAxis (
            rigidbody.angularVelocity.magnitude * Mathf.Rad2Deg * m_stability / m_speed,
            rigidbody.angularVelocity
        ) * transform.forward;
 
    Vector3 torqueVector = Vector3.Cross (predictedUp, Vector3.forward);
    rigidbody.AddTorque (torqueVector * m_speed * m_speed);
  }
}