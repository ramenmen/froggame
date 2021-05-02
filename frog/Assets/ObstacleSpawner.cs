using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // gameObject.GetComponent<SpriteRenderer>().enabled = false;
        int idxToInstantiate = GetRandomWeightedIndex(GameManager.Instance.difficultySums);
        Instantiate(GameManager.Instance.obstacles[idxToInstantiate], transform.position, Quaternion.identity, transform);
        Debug.Log("START!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetRandomWeightedIndex(int[] raritySums)
    {
        // Step through all the possibilities, one by one, checking to see if each one is selected.
        int chosen = Random.Range(0, raritySums[raritySums.Length - 1]);

        for (int i = 0; i < raritySums.Length; i++)
        {
            // Do a probability check with a likelihood of weights[index] / weightSum.
            if (chosen < raritySums[i])
            {
                return i;
            }
        }
        return 0;
    }
}
