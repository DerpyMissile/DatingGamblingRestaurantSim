using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorTiles : MonoBehaviour
{
    void Awake()
    {
        Tilemap tilemap = GetComponent<Tilemap>();
        GridLayout gridLayout = tilemap.layoutGrid;

        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                    // Debug.Log("Tile position: " + tilemap.GetCellCenterWorld(new Vector3Int(x, y, 0)));
                    // Globals.chairPositions.Add(tilemap.GetCellCenterWorld(new Vector3Int(x, y, 0)));
                    Debug.Log("Tile position: " + gridLayout.CellToWorld(new Vector3Int(x, y, 0)));
                    Globals.doorPositions.Add(gridLayout.CellToWorld(new Vector3Int(x, y-2, 0))); // idk why -2 works
                }
            }
        }

        Debug.Log($"Tilemap Bounds: Min={bounds.min}, Max={bounds.max}, Size={bounds.size}");   
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
