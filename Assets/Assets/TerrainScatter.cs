using UnityEngine;

public class TerrainScatter : MonoBehaviour
{
    [Header("References")]
    public Terrain terrain;
    public GameObject prefab;

    [Header("Settings")]
    public int count = 500;

    void Start()
    {
        Scatter();
    }

    void Scatter()
    {
        if (terrain == null || prefab == null)
        {
            Debug.LogError("Terrain or Prefab not assigned!");
            return;
        }

        TerrainData terrainData = terrain.terrainData;
        Vector3 terrainPosition = terrain.transform.position;
        Vector3 terrainSize = terrainData.size;

        for (int i = 0; i < count; i++)
        {
            float x = Random.Range(0f, terrainSize.x);
            float z = Random.Range(0f, terrainSize.z);

            float worldX = terrainPosition.x + x;
            float worldZ = terrainPosition.z + z;

            float y = terrain.SampleHeight(new Vector3(worldX, 0, worldZ))
                      + terrainPosition.y;

            Vector3 spawnPosition = new Vector3(worldX, y, worldZ);

            GameObject instance = Instantiate(prefab, spawnPosition, Quaternion.identity);
            instance.transform.parent = transform;
        }
    }
}