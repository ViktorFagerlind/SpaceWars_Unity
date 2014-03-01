using UnityEngine;
using System.Collections;

public class FollowPath : MonoBehaviour
{
  void Start () 
  {
    iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("dark path"), "time", 10)); 
  }
}
