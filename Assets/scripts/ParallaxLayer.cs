using UnityEngine;
using System.Collections;

public class ParallaxLayer : MonoBehaviour 
{
  public  float m_speed          = 1f;
  public  float m_size           = 100f;
  public  float m_threasholdPos  = 0f;

	// Use this for initialization
	void Start () 
  {
	}
	
	// Update is called once per frame
	void Update () 
  {
	  transform.position = new Vector3 (transform.position.x, transform.position.y - m_speed, transform.position.z);
    
    if (transform.position.y < m_threasholdPos)
      transform.position = new Vector3 (transform.position.x, transform.position.y + m_size, transform.position.z);
	}
}
