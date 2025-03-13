using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    
    // Verweis auf den TreeDestructManager (am besten per Inspektor)
    public TreeDestructionManager treeManager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            // Ermittle die Weltposition der Maus (Kamera Umrechnen)
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // In 2D liegt die Tilemap meist auf Z=0
            mouseWorldPos.z = 0;

            // Rufe die Schadensmethode auf
            treeManager.DamageTree(mouseWorldPos);
        }
    }
}
