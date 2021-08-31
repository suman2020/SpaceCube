using UnityEngine;
using UnityEngine.UI;

namespace SpaceShop
{
    public class UI : MonoBehaviour
    {
        public int totalCoins = 5000;
        public ShopData shopData;
        public GameObject[] cubeList;                    
        public Text unlockBtnText, cubeNameText; 
        public Text totalCoinsText;
        public Button unlockBtn, nextBtn, previousButton;
        public Save save;

        private int currentIndex = 0;
        private int selectedIndex = 0;

        private void Start()
        {
            save.Initialize();
            selectedIndex = shopData.SelectedIndex;
            currentIndex = selectedIndex;                           //set the currentIndex
            totalCoinsText.text = "" + totalCoins;

            CubeInfo();

            unlockBtn.onClick.AddListener(() => Buy());      //add listner to button
            nextBtn.onClick.AddListener(() => Next());                //add listner to button
            previousButton.onClick.AddListener(() => Previous());

            cubeList[currentIndex].SetActive(true);

            if (currentIndex == 0) previousButton.interactable = false;     
            if (currentIndex == shopData.storeitem.Length - 1) nextBtn.interactable = false;

            UnlockButtonStatus();
        }

        private void CubeInfo()
        {
            cubeNameText.text = shopData.storeitem[currentIndex].item_Name;
        }
        public void Next()
        {
            if (currentIndex < shopData.storeitem.Length - 1)
            {
                cubeList[currentIndex].SetActive(false);
                currentIndex++;
                cubeList[currentIndex].SetActive(true);
                CubeInfo();
               
                if (currentIndex == shopData.storeitem.Length - 1)
                {
                    nextBtn.interactable = false;
                }

                if (!previousButton.interactable)
                {
                    previousButton.interactable = true;
                }
                UnlockButtonStatus();
            }
           
        }

        private void Previous()
        {
            if (currentIndex > 0)
            {
                cubeList[currentIndex].SetActive(false);
                currentIndex--;
                cubeList[currentIndex].SetActive(true);
                CubeInfo();

                if (currentIndex == 0)
                {
                    previousButton.interactable = false;
                }

                if (!nextBtn.interactable)
                {
                    nextBtn.interactable = true;
                }
                UnlockButtonStatus();
            }
           
        }

        private void Buy()
        {
            bool yesSelected = false;   
            if (shopData.storeitem[currentIndex].is_Bought)    
            {
                yesSelected = true;                            
            }
            else  
            {
               
                if (totalCoins >= shopData.storeitem[currentIndex].cost)
                {
                   
                    totalCoins -= shopData.storeitem[currentIndex].cost;
                    totalCoinsText.text = "" + totalCoins;         
                    yesSelected = true;                             
                    shopData.storeitem[currentIndex].is_Bought= true; 
        
                }
            }

            if (yesSelected)
            {
                unlockBtnText.text = "Selected";                 
                selectedIndex = currentIndex;
                //PlayerPrefs.SetInt("SelectedItem", selectedIndex); 
                shopData.SelectedIndex = selectedIndex;
                unlockBtn.interactable = false;                    
            }

        }

        private void UnlockButtonStatus()
        {
           
            if (shopData.storeitem[currentIndex].is_Bought)
            {

                unlockBtn.interactable = selectedIndex != currentIndex ? true : false;
             
                unlockBtnText.text = selectedIndex == currentIndex ? "Selected" : "Select";
            }
            else
            {
                unlockBtn.interactable = true; 
                unlockBtnText.text = "Cost " + shopData.storeitem[currentIndex].cost; 
            }
        }
    }

}