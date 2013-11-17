using UnityEngine;
using System.Collections;

public class CollisionObject : MonoBehaviour
{
  public float m_damageOutput = 0f;
  public float m_health       = 100f;
  
  public virtual void OnHit (Transform otherObject, ContactPoint contact) {}
  
  public virtual void OnKilled () {}
  
  public float damageOutput
  {
    get { return m_damageOutput; }
  }
  
  public float health
  {
    get { return m_health;  }
    set { m_health = value; }
  }
  
  void OnCollisionEnter (Collision collision)
  {
    ContactPoint contact      = collision.contacts[0];    
    Transform    otherObject  = contact.otherCollider.transform; // collision.collider.transform.root;
    
    OnHit (otherObject, contact);
    
    CollisionObject otherCollisionObject = otherObject.GetComponent<CollisionObject>();
    
    health = health - otherCollisionObject.damageOutput;
    
    if (health < 0f)
    {
      OnKilled ();
    }
  }  
}
