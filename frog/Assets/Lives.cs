using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public GameObject[] hearts;
    // Start is called before the first frame update
    void Start()
    {
        hearts = new GameObject[3];
        hearts[0] = transform.GetChild(0).gameObject;
        hearts[1] = transform.GetChild(1).gameObject;
        hearts[2] = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseLife()
    {
        foreach (GameObject heart in hearts) {
            if (heart.activeSelf) {
                heart.SetActive(false);
                break;
            }
        }
    }

    public void GainLife()
    {
        foreach (GameObject heart in hearts) {
            if (!heart.activeSelf) {
                heart.SetActive(true);
                break;
            }
        }
    }
}
