using UnityEngine;
using UnityEngine.UI;

public class CellInformation : MonoBehaviour
{
    private Image image;
    [SerializeField] private Sprite iconStick, iconEmty;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void SetItemIcon(string name)
    {
        switch (name)
        {
            case "Emty":
                image.sprite = iconEmty;
                Debug.Log("Icon " + this.gameObject.name + " is Empty");
                return;
            case "Stick":
                image.sprite = iconStick;
                Debug.Log("Icon " + this.gameObject.name + " is Stick");
                return;
            case "help me":
                return;
        }
    }
}
