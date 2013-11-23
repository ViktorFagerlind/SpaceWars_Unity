using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
  public Vector3 m_rotation_speed;
    
  // Use this for initialization
  void Start ()
  {
  }
  
  // Update is called once per frame
  void Update ()
  {
    transform.Rotate (m_rotation_speed);
  }
}
