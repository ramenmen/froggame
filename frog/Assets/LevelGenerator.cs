using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float DISTANCE_TO_SPAWN = 50f;

    [SerializeField] private Transform StartLevel;
    [SerializeField] private Player player;

    private Vector3 lastEndPosition;
    // [SerializeField] private Transform transform_1;
    private int test = 4;

    private void Awake() {
        // Transform lastTransform = ground;
        // lastTransform = 
        lastEndPosition = SpawnLevelPart(StartLevel.Find("ground").Find("EndPosition").position).position;

    }

    private void Update() {
        Vector3 playerPosition = player.transform.position;
        if (Mathf.Abs(playerPosition.x - lastEndPosition.x) < DISTANCE_TO_SPAWN) {
            SpawnLevelPart();
        }
        // Debug.Log("player position: " + playerPosition.x + " " + playerPosition.y + " " + playerPosition.z + " " + "distance: " + (playerPosition.x - lastEndPosition.x).ToString());
    }

    private void SpawnLevelPart() {
        Transform lastSpawnedLevelPart = SpawnLevelPart(lastEndPosition);
        lastEndPosition = lastSpawnedLevelPart.Find("ground").Find("EndPosition").position;
        // Debug.Log("lastEndPosition: " + lastEndPosition.x + " " + lastEndPosition.y + " " + lastEndPosition.z);
    }

    private Transform SpawnLevelPart(Vector3 position) {
        Transform transform = Instantiate(StartLevel, position, Quaternion.identity);
        return transform;
    }
}
