using UnityEngine;
using System.Collections;


public class TimeFactory : MonoBehaviour 
{
  // --- Types ---------------------------------------------------------------------------------------------------------
  
  [System.Serializable]
  public class FactoryItem
  {
    public Transform entity       = null;
    public float     startTime    = 0;
    public float     intervalTime = 1;
    public float     endTime      = 10;
  }
 
  // --- Public attributes ---------------------------------------------------------------------------------------------
  
  public FactoryItem[] factoryItems; 
  
  // --- Private Attributes --------------------------------------------------------------------------------------------
  
  private float[]      lastCreationTimes;
  
  // --- Methods -------------------------------------------------------------------------------------------------------
  
	void Start ()
  {
    lastCreationTimes = new float[factoryItems.Length];
    
    for (int i=0; i < lastCreationTimes.Length; i++)
      lastCreationTimes[i] = 0f;
	}
        
  void Update ()
  {
    float currentTime = Time.realtimeSinceStartup;
    
    for (int i=0; i < factoryItems.Length; i++)
    {
      FactoryItem item = factoryItems[i];
      
      // Time to stop generating?
      if (currentTime > item.endTime)
        continue;
      
      float deltaTime = lastCreationTimes[i] == 0f ? item.startTime : item.intervalTime;
      
      // Should we generate?
      if (lastCreationTimes[i] + deltaTime < currentTime)
      {
        Instantiate (item.entity, Vector3.zero, Quaternion.identity);
        lastCreationTimes[i] = currentTime;
      }
    }
  }
  
}
