using UnityEngine;
using System.Collections.Generic;

public class ResultPlateTrigger : MonoBehaviour
{
    [HideInInspector] public List<GameObject> cupcakesOnPlate = new List<GameObject>();
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cupcake"))
        {
            if(!cupcakesOnPlate.Contains(other.gameObject))
                cupcakesOnPlate.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Cupcake"))
            cupcakesOnPlate.Remove(other.gameObject);
    }
}
