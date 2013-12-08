using UnityEngine;
using System.Collections;

public class DieAfterParticleSystem : MonoBehaviour
{
 
  // Update is called once per frame
  void Update ()
  {
    if (!particleSystem.isPlaying)
      Destroy (transform.root.gameObject);
  }
}
