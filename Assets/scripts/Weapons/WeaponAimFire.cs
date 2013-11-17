using UnityEngine;
using System.Collections;

public class WeaponAimFire : Weapon
{
  public float        m_maxAngle;
  
  private Transform   m_target;
  
  // Use this for initialization
  void Start () 
  {
    m_target = GameObject.FindGameObjectWithTag ("Player").transform;
  }
  
  // Update is called once per frame
  void Update () 
  {
    if (m_target == null)
      return;
    
    if (IsTimeToShoot ())
    {
      Vector3 dir = m_target.position - transform.position;
      float angle = Vector3.Angle (transform.forward, dir);
      
      if (Mathf.Abs (angle) <= m_maxAngle)
      {
        Shoot ();    
      }
    }
  }
}
