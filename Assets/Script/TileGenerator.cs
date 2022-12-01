 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] tilePrefab;
    [SerializeField] private Transform player;

    private List<GameObject> activeTiles = new List<GameObject>();

    private float spawnPos = 0;
    private float tileLength = 11.2f;
    private int startTiles = 5;
    private float leftBound = -15;

    private void Start()
    {
        for (var i = 0; i < startTiles; i++)
        {
            SpawnTile(Random.Range(0, tilePrefab.Length));
        }
    }


    private void Update()
    {
        if (activeTiles.Count >= 6)
        {
            DeleteTile();
        }
        else
        {
            SpawnTile(Random.Range(0, tilePrefab.Length));
        }
    }
    private void SpawnTile(int tileIndex)
    {
        GameObject nextTile = (GameObject)Instantiate(tilePrefab[tileIndex],
             transform.right * spawnPos, transform.rotation);
        activeTiles.Add(nextTile);
        spawnPos += tileLength;
    }
    private void DeleteTile()
    {
        if (transform.position.x <= leftBound)
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);

        }
    }
}
