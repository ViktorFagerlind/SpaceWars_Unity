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
	  transform.localPosition = transform.localPosition + new Vector3 (0, 0, - m_speed);
    
    if (transform.localPosition.z < m_threasholdPos)
      transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + m_size);
	}
}
