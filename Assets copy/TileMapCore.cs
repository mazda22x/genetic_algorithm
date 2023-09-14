using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapCore : MonoBehaviour
{
    public Tile baseTile;

    public int worldSize = 5;

    Tilemap tilemap;

    Camera mainCamera;

    GameObject[,] unitmap;

    // Start is called before the first frame update
    void Awake()
    {
        unitmap = new GameObject[worldSize * 2, worldSize * 2];

        int rows = unitmap.GetUpperBound(0) + 1;    // количество строк
        int columns = unitmap.Length / rows;        // количество столбцов

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
                unitmap[i, j] = null;

        tilemap = GetComponent<Tilemap>();
        mainCamera = Camera.main;

        for (int i = -worldSize; i < worldSize; i++)
        {
            for (int j = -worldSize; j < worldSize; j++)
            {
                tilemap.SetTile(new Vector3Int(i, j), baseTile);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaceUnit(GameObject unit)
    {
        int _rX = Random.Range(-worldSize, worldSize);
        int _rY = Random.Range(-worldSize, worldSize);

        if (unitmap[_rX + worldSize, _rY + worldSize] != null)
        {
            DestroyImmediate(unitmap[_rX + worldSize, _rY + worldSize]);
        }
        unitmap[_rX + worldSize, _rY + worldSize] = unit;
        unit.transform.position = tilemap.CellToWorld(tilemap.WorldToCell(new Vector3Int(_rX, _rY)));

    }
}
