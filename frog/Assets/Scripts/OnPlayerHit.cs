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
        //obstacle
        if (other.GetComponent<Obstacle>() != null) {
            GameManager.Instance.OnHit();
            SoundManager.Instance.PlaySound(soundEffects.hit);
        }
        //non heart collectible
        else if (other.GetComponent<Collectible>() != null) {
            if (other.GetComponent<Heart>() != null) {
                GameManager.Instance.OnHeartCollect();
            }
            else {
                GameManager.Instance.Score += other.GetComponent<Collectible>().points;
                score.AddScore();
            }
            Destroy(other);
            SoundManager.Instance.PlaySound(soundEffects.coin);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
