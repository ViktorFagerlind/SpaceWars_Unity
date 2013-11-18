using UnityEngine;
using System.Collections;

public class Movable : MonoBehaviour
{
  private Vector3 m_acceleration;
  private Vector3 m_speed;
  
  public Vector3 speed
  {
      get { return m_speed;  }
      set { m_speed = value; }
  }
  
  public Vector3 acceleration
  {
      get { return m_acceleration;  }
      set { m_acceleration = value; }
  }
  
  public void AddAcceleration (Vector3 acceleration)
  {
    m_acceleration += acceleration;
  }
  
  void Start ()
  {
    m_acceleration  = new Vector3 (0,0,0);
    m_speed         = new Vector3 (0,0,0);
  }
  
  void Update ()
  {
    m_speed += m_acceleration;
    
    transform.Translate (m_speed);
  }
}


