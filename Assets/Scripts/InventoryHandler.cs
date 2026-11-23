using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] inventoryCells;
    [SerializeField] private string[] itemNames = { "Empty", "Stick"};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var cell in inventoryCells)
        {
            cell.GetComponent<CellInformation>().SetItemIcon(itemNames[0]);
        }
    }
}
