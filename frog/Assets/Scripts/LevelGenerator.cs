using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float DISTANCE_TO_SPAWN = 50f;

    [SerializeField] private Transform BackgroundSegment;
    [SerializeField] private PlayerController player;
    private Transform secondLastSpawnedPart;
    private Transform lastSpawnedPart;
    private Transform currentPart;

    private Vector3 endPosition;

    private void Start() {
        currentPart = BackgroundSegment;
        endPosition = BackgroundSegment.Find("EndPosition").position;
    }

    private void Update() {
        Vector3 playerPosition = player.transform.position;
        if (Mathf.Abs(playerPosition.x - endPosition.x) < DISTANCE_TO_SPAWN) {
            SpawnNextPart();
        }
        // Debug.Log("player position: " + playerPosition.x + " " + playerPosition.y + " " + playerPosition.z + " " + "distance: " + (playerPosition.x - lastEndPosition.x).ToString());
    }

    private void SpawnNextPart() {
        if (secondLastSpawnedPart != null && secondLastSpawnedPart.parent == transform) {
            Destroy(secondLastSpawnedPart.gameObject);
        }
        
        secondLastSpawnedPart = lastSpawnedPart;
        lastSpawnedPart = currentPart;
        currentPart = Instantiate(BackgroundSegment, endPosition, Quaternion.identity, transform);
        endPosition = currentPart.Find("EndPosition").position;
        // Debug.Log("lastEndPosition: " + lastEndPosition.x + " " + lastEndPosition.y + " " + lastEndPosition.z);
    }
}
