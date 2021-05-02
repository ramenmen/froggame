using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float DISTANCE_TO_SPAWN = 200f;

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
        if (Vector3.Distance(playerPosition, lastEndPosition) < DISTANCE_TO_SPAWN) {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart() {
        Transform lastSpawnedLevelPart = SpawnLevelPart(lastEndPosition);
        lastEndPosition = lastSpawnedLevelPart.Find("ground").Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Vector3 position) {
        Transform transform = Instantiate(StartLevel, position, Quaternion.identity);
        return transform;
    }
}
