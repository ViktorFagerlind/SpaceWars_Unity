using UnityEngine;
using System.Collections;

public class InitialRigidbodyProperties : MonoBehaviour
{
  public Vector3 m_scale          = new Vector3 (1f, 1f, 1f);
  public Vector3 m_scaleRandom    = new Vector3 (1f, 1f, 1f);
  
  public Vector3 m_position       = new Vector3 (0f, 0f, 0f);
  public Vector3 m_positionRandom = new Vector3 (0f, 0f, 0f);

  public Vector3 m_velocity       = new Vector3 (0f, 0f, 0f);
  public Vector3 m_velocityRandom = new Vector3 (0f, 0f, 0f);
  
  public Vector3 m_rotation       = new Vector3 (0f, 0f, 0f);
  public Vector3 m_rotationRandom = new Vector3 (0f, 0f, 0f);
  
  
  // Use this for initialization
  void Start ()
  {
    transform.localScale = m_scale + new Vector3 (Random.Range (-m_scaleRandom.x, m_scaleRandom.x),
                                                  Random.Range (-m_scaleRandom.y, m_scaleRandom.y),
                                                  Random.Range (-m_scaleRandom.z, m_scaleRandom.z));
    
    rigidbody.position = m_position + new Vector3 (Random.Range (-m_positionRandom.x, m_positionRandom.x),
                                                   Random.Range (-m_positionRandom.y, m_positionRandom.y),
                                                   Random.Range (-m_positionRandom.z, m_positionRandom.z));
    
    transform.position = rigidbody.position;
    
    rigidbody.velocity = m_velocity + new Vector3 (Random.Range (-m_velocityRandom.x, m_velocityRandom.x),
                                                   Random.Range (-m_velocityRandom.y, m_velocityRandom.y),
                                                   Random.Range (-m_velocityRandom.z, m_velocityRandom.z));
    
    rigidbody.angularVelocity = m_rotation + new Vector3 (Random.Range (-m_rotationRandom.x, m_rotationRandom.x),
                                                          Random.Range (-m_rotationRandom.y, m_rotationRandom.y),
                                                          Random.Range (-m_rotationRandom.z, m_rotationRandom.z));
    
    // Change properties depending on size
    float magnitude = transform.localScale.magnitude / (new Vector3 (1,1,1)).magnitude;
    
    print (magnitude);
    
    rigidbody.mass *= magnitude;
    
    SphereCollider sphereCollider = GetComponent("SphereCollider") as SphereCollider;
    if (sphereCollider != null) {sphereCollider.radius *= magnitude;}
    
    BoxCollider boxCollider = GetComponent("BoxCollider") as BoxCollider;
    if (boxCollider != null)    {boxCollider.size      *= magnitude;}
  }
}
