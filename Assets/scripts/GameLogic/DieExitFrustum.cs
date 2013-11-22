using UnityEngine;
using System.Collections;

public class DieExitFrustum : MonoBehaviour
{
  void OnBecameInvisible ()
  {
    Destroy (transform.root.gameObject);
  }
}
