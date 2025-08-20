using UnityEngine;
using UnityEngine.Tilemaps;

public class ChairTiles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Tilemap tilemap = GetComponent<Tilemap>();

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
                    Debug.Log("Tile position: " + tilemap.GetCellCenterWorld(new Vector3Int(x, y, 0)));
                    Globals.chairPositions.Add(tilemap.GetCellCenterWorld(new Vector3Int(x, y, 0)));
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
