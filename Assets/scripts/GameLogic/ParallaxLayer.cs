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
	  transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y - m_speed, transform.localPosition.z);
    
    if (transform.localPosition.y < m_threasholdPos)
      transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + m_size, transform.localPosition.z);
	}
}
