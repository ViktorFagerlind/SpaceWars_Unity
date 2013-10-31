using UnityEngine;
using System.Collections;

public class ShotExplosion : MonoBehaviour
{

  // Use this for initialization
  void Start ()
  {
 
  }
 
  // Update is called once per frame
  void Update ()
  {
    if (!particleSystem.isPlaying)
      Destroy (gameObject);
  }
}
