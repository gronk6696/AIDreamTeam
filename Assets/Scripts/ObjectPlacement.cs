using UnityEngine;
using UnityEngine.UI;
using UnityEngine.ProBuilder;
using TMPro;

public class ObjectPlacement : MonoBehaviour
{
    
    public GameObject PlacementPanel;
    public GameObject[] prefabs;
    public Button[] buttons;
    public Transform[] planes;
    private GameObject selectedPrefab;
    public TextMeshProUGUI AvailableFundsText;
    private int CurrentFunds = 500;
    public int purchaseCost;
    public bool SuccessfullyPurchased = false;

        // Set and display the Available Funds resource.
        //Hide the placement grid on start.
        // Attach OnClick event listeners to each placement button.

    void Start()
    {
        AvailableFundsText.text = CurrentFunds.ToString();
        PlacementPanel.SetActive(false);


        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Required for closure
            buttons[i].onClick.AddListener(() => PlaceObjectOnPlane(index));
        }
    }

    //Spend available funds, 
    //set the purchase flag to true, 
    //activate the placement grid.

    public void BuyObject(int purchaseCost){
        if(CurrentFunds >= purchaseCost){
            CurrentFunds = CurrentFunds -= purchaseCost;
            AvailableFundsText.text = CurrentFunds.ToString();
            SuccessfullyPurchased = true;
        }
    }



    public void SelectPrefab(int index)
    {
        //If an object is purchased, activate the grid for placing.
        // once it's placed, set the purchase bool to false and close the grid.

        if(SuccessfullyPurchased){
            PlacementPanel.SetActive(true);
         if (index >= 0 && index < prefabs.Length)
            {
             selectedPrefab = prefabs[index];
            }
        }
        else {
             SuccessfullyPurchased = false;
        }

        index = 0;
    }

    public void PlaceObjectOnPlane(int index)
    {
        // if a placement button is selected and there's room on the board, 
        // instantiate the chosen object on the tile that matches the placement button.
        // close the placement grid, and mark that space as non interactable.
        //change the button colour to red to indicate it can't be selected again. 
        if (selectedPrefab != null && index >= 0 && index < planes.Length)
        {
            Vector3 position = planes[index].position;
            Quaternion rotation = planes[index].rotation;
            Instantiate(selectedPrefab, position, rotation);
            PlacementPanel.SetActive(false);
            SuccessfullyPurchased = false;
            buttons[index].interactable = false; // Disable button
            buttons[index].GetComponent<Image>().color = Color.red; // Change button color
        }
    }
}

