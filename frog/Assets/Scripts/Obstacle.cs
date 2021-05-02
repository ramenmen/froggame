using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int points;
    public GameObject coinSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        int idxToInstantiate = GetRandomWeightedIndex(GameManager.Instance.rarities);
        if (idxToInstantiate > 0) {
            Instantiate(GameManager.Instance.spawnables[idxToInstantiate], coinSpawn.transform.position, Quaternion.identity, coinSpawn.transform);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetRandomWeightedIndex(int[] weights)
    {
        // Get the total sum of all the weights.
        int weightSum = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            weightSum += weights[i];
            weights[i] = weightSum;
        }
    
        // Step through all the possibilities, one by one, checking to see if each one is selected.
        int chosen = Random.Range(0, weightSum);

        for (int i = 0; i < weights.Length; i++)
        {
            // Do a probability check with a likelihood of weights[index] / weightSum.
            if (chosen < weights[i])
            {
                return i;
            }
        }
        return 0;
    }
}
