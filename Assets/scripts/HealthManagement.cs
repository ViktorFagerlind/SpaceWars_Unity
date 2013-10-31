using UnityEngine;
using System.Collections;

public class HealthManagement : MonoBehaviour
{

  // Use this for initialization
  void Start ()
  {
  }
 
  // Update is called once per frame
  void Update ()
  {
  }
  
  void OnCollisionEnter (Collision collision)
  {
    foreach (ContactPoint contact in collision.contacts) 
    {
      print (contact.point);
      
//      Debug.DrawRay (contact.point, contact.normal, Color.white);
    }
    //if (collision.relativeVelocity.magnitude > 2)
    //  audio.Play ();
  
  }
}
