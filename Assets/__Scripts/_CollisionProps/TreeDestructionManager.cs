using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TreeDestructionManager : MonoBehaviour
{
    public Tilemap collisionTilemap;
    // Referenz Tilemap mit Bäumen
    public TileBase treeTile;
    // Tile, welches Baumstumpf repräsentiert
    public TileBase stumpTile;
    // Anfangsleben für jeden Baum
    [SerializeField] public int initialTreeHealth = 3;
    private Dictionary<Vector3Int, int> treeHealthDict = new Dictionary<Vector3Int, int>();


    void Start()
    {
        // Alle Zeilen innerhalb der TilemapGrenzen durchlaufen
        foreach (Vector3Int pos in collisionTilemap.cellBounds.allPositionsWithin) {
            if (collisionTilemap.GetTile(pos) == treeTile) { //Prüfe ob in der Zelle ein Baum liegt
                treeHealthDict[pos] = initialTreeHealth;
            }
        }
    }

    public void DamageTree(Vector3 worldPosition) { //Methode zum beschädigen von Bäumen
        // Weltposition in Tilemap-Zellenkoordinaten umrechnen
        Vector3Int cellPos = collisionTilemap.WorldToCell(worldPosition);
        if (treeHealthDict.ContainsKey(cellPos)) {
            treeHealthDict[cellPos]--;
            Debug.Log("Baum an " + cellPos + " Schaden erhalten. Verbleibende HP: " + treeHealthDict[cellPos]);
            // Animation für Treffer Effekt hinzufügen
            //... 
            // Wenn Keine HP mehr
            if (treeHealthDict[cellPos] <= 0) {
                // Ersetze den Baum durch Baumstumpf
                collisionTilemap.SetTile(cellPos, stumpTile);
                treeHealthDict.Remove(cellPos);
                Debug.Log("Baum an " + cellPos + " wurde zerstört!");
            }

        }
    }
}
