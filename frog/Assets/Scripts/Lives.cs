using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public GameObject[] hearts;
    public GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        hearts = new GameObject[3];
        hearts[0] = transform.GetChild(0).gameObject;
        hearts[1] = transform.GetChild(1).gameObject;
        hearts[2] = transform.GetChild(2).gameObject;
        manager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLives(manager.Lives);
    }

    public void UpdateLives(int newLives) {
        for (int i = 0; i < newLives; i++) {
            hearts[i].SetActive(true);
        }
        for (int i = newLives; i < 3; i++) {
            hearts[i].SetActive(false);
        }
    }
}
