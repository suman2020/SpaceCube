using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TileGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private int noOfTilesOnScreen = 2;
    private int tile_length = 50;
    Vector3 pos = new Vector3(0, 0, 0);
    public Transform playerTransform;
    private List<GameObject> activeTiles;
    private float destroy_after = 30.0f;
    void Start()
    {
        activeTiles = new List<GameObject> ();
        for (int i = 0; i < noOfTilesOnScreen; i++)
        {    
            SpawnTile();
           
        }
        
    }
    private void Update()
    {
        if (playerTransform.position.z - destroy_after > (pos.z - noOfTilesOnScreen * tile_length))
        {
            SpawnTile();
            DeleteTile();
        }
    }
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(tilePrefabs[RandomIndex()], pos,Quaternion.identity);
        go.transform.SetParent(transform); // spawn objects are grouped together under TileManager
        pos.z += 50;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    private int RandomIndex()
    {
        int randomIndex = Random.Range(0, tilePrefabs.Length);
        return randomIndex;
    }
}
