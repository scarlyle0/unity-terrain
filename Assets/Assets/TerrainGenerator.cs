using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public Terrain terrain;

    [Header("Noise Settings")]
    public float noiseScale = 50f;
    public float heightMultiplier = 0.2f;
    public Vector2 noiseOffset;

    void Start()
    {
        Generate();
    }

    void Generate()
    {
        TerrainData data = terrain.terrainData;

        int width = data.heightmapResolution;
        int height = data.heightmapResolution;

        float[,] heights = new float[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                float xCoord = (x + noiseOffset.x) / noiseScale;
                float zCoord = (z + noiseOffset.y) / noiseScale;

                float noise = Mathf.PerlinNoise(xCoord, zCoord);
                heights[x, z] = noise * heightMultiplier;
            }
        }

        data.SetHeights(0, 0, heights);
    }
}