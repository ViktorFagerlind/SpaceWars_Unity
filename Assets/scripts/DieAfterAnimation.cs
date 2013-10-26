using UnityEngine;
using System.Collections;

public class DieAfterAnimation : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
  {
	  if (!animation.isPlaying)
      Destroy (gameObject);
	}
}
