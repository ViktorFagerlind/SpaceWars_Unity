﻿using UnityEngine;
using System.Collections;

public class WeaponRepeater : Weapon
{
	// Use this for initialization
	void Start () 
  {
	}
  
	// Update is called once per frame
	void Update () 
  {
    if (IsTimeToShoot ())
      Shoot ();
	}
}
