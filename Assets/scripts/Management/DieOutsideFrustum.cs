using UnityEngine;
using System.Collections;

public class DieOutsideFrustum : MonoBehaviour 
{
  void Update ()
  {
    if (!renderer.isVisible)
      Destroy (gameObject);
  }
  
  /* void OnBecameInvisible ()
  {
    Destroy (gameObject);
  }*/
}
