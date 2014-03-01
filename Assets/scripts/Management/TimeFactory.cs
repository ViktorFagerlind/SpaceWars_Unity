using UnityEngine;
using System.Collections;


public class TimeFactory : MonoBehaviour 
{
  // --- Types ---------------------------------------------------------------------------------------------------------
  
  [System.Serializable]
  public class FactoryItem
  {
    public  Transform entity           = null;
    public  float     startTime        = 0;
    public  float     intervalTime     = 1;
    public  float     endTime          = 10;
    public  int       endCount         = 10;

    [HideInInspector]
    public bool      done              = false;
    [HideInInspector]
    public float     lastCreationTime  = 0;
    [HideInInspector]
    public int       count             = 0;
  }
 
  // --- Public attributes ---------------------------------------------------------------------------------------------
  
  public FactoryItem[] factoryItems; 
  
  // --- Private Attributes --------------------------------------------------------------------------------------------
  

  // --- Methods -------------------------------------------------------------------------------------------------------
  
	void Start ()
  {
    foreach (FactoryItem item in factoryItems)
    {
      item.done             = false;
      item.lastCreationTime = 0.0f;
      item.count            = 0;
    }
  }
        
  void Update ()
  {
    bool noItemsLeft = true;

    float currentTime = Time.realtimeSinceStartup;
    
    foreach (FactoryItem item in factoryItems)
    {
      // Time to stop generating?
      if (item.done || currentTime > item.endTime || item.count >= item.endCount)
      { 
        item.done = true;
        continue;
      }

      noItemsLeft = false;

      float deltaTime = item.lastCreationTime == 0f ? item.startTime : item.intervalTime;

      // Should we generate?
      if (item.lastCreationTime + deltaTime < currentTime)
      {
        Instantiate (item.entity, Vector3.zero, Quaternion.identity);

        item.lastCreationTime = currentTime;
        item.count++;
      }
    }

    if (noItemsLeft)
      Destroy (gameObject);
  }
  
}
