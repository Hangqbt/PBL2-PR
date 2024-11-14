using UnityEngine;

public class MenuManager : MonoBehaviour

{
    public GameObject initialButton; //initial button
    public GameObject[] secondaryButtons; //new button


    //When the firstr button hit
    public void ShowSecondaryButtons()
    {
        initialButton.SetActive(false);

        foreach (GameObject button in secondaryButtons)
        {
            button.SetActive(true);
        }
    }
    
   
}
