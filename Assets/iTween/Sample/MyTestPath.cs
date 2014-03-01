using UnityEngine;
using System.Collections;

public class MyTestPath : MonoBehaviour 
{
	void Start () 
  {
    iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("testPath"), "time", 3));	
	}
}
