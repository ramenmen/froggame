using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerHit : MonoBehaviour
{
    private Score score;

    void Start() {
        score = GetComponent<Score>();
    }
    
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject other = col.gameObject;
        Debug.Log(other.name);
        if (other.GetComponent<Obstacle>() != null) {

        }
        else if (other.GetComponent<Collectible>() != null) {
            score.AddScore(other.GetComponent<Collectible>().points);
            Destroy(other);
            SoundManager.Instance.PlaySound(soundEffects.coin);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
