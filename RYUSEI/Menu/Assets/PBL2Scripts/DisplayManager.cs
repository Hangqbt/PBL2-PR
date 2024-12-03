using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    // Start is called before the first frame update
    void Start()
    {
        displayText.text = SharedData.ValueToDisplay;
    }
}
