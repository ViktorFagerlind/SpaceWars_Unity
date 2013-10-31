using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour
{
  public GameObject m_explosion;
  
  void Update ()
  {
    if (!renderer.isVisible)
      Destroy (gameObject);
  }
  
  void OnCollisionEnter(Collision collision) 
  {
    ContactPoint  contact = collision.contacts[0];
    Quaternion    rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
    Vector3       pos = contact.point;
    
    Instantiate (m_explosion, pos, rot);
    
    Destroy (gameObject);
    
    print ("hit: " + pos);
  }

}
