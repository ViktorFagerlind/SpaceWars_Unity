using UnityEngine;
using System.Collections;

public class ExplosionPower : MonoBehaviour {
  public float radius =  5.0f;
  public float power  = 10.0f;

  void Start() {
    Vector3 explosionPos = transform.position;
    Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);

    foreach (Collider hit in colliders) 
    {
      // Apply force on rigid bodies that are not shots
      if (hit                  != null && 
          hit.rigidbody        != null &&
          hit.gameObject.layer != LayerMask.NameToLayer ("Protagonist shots") &&
          hit.gameObject.layer != LayerMask.NameToLayer ("Enemy shots"))
        hit.rigidbody.AddExplosionForce (power, explosionPos, radius);
    }
  }
}
