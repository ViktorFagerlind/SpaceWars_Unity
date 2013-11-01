using UnityEngine;
using System.Collections;

public class CollisionExplosionObject : CollisionObject
{
  public GameObject m_deathExplosion;
  
  public GameObject m_hitExplosion;
  
  public override void OnKilled ()
  {
    if (m_deathExplosion != null)    
      Instantiate (m_deathExplosion, transform.position, transform.rotation);
    
    Destroy (gameObject);
  }
  
  public override void OnHit (Transform otherObject, ContactPoint contact)
  {
    Quaternion    rot = Quaternion.FromToRotation (Vector3.up, contact.normal);
    Vector3       pos = contact.point;
    
    if (m_hitExplosion != null)    
      Instantiate (m_hitExplosion, pos, rot);
  }
}
