using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spells : MonoBehaviour
{
    [System.Serializable] class UpgradeSpells
    {
        public Sprite Image;
        public int Price;
       // public int level;
        public bool IsUpgraded = false;
    }

    [SerializeField] List<UpgradeSpells> UpgradeSpellsList;
    [SerializeField] Animator NoCoinsAnim;
    [SerializeField] Text CoinsText;

    GameObject ItemTemplate;
    GameObject g;
    //Vector3 rotationEuler;
    Button UpgradeBtn;
    [SerializeField] Transform ShopScrollView;

    void Start()
    {
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;

        int len = UpgradeSpellsList.Count;

        for (int i = 0; i < len; i++)
        {
            g = Instantiate(ItemTemplate, ShopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = UpgradeSpellsList[i].Image;
            g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = UpgradeSpellsList[i].Price.ToString();
            UpgradeBtn = g.transform.GetChild(2).GetComponent<Button>();
            UpgradeBtn.interactable = !UpgradeSpellsList[i].IsUpgraded;
            UpgradeBtn.AddEventListener(i, OnUpgradeItemBtnClicked);
        }
        
        Destroy(ItemTemplate);
        SetCoinsUI();
    }

    void OnUpgradeItemBtnClicked(int itemIndex)
    {
        if (GameHandler.Instance.HasEnoughCoins(UpgradeSpellsList[itemIndex].Price))
        {
            GameHandler.Instance.UseCoins(UpgradeSpellsList[itemIndex].Price);
            UpgradeSpellsList[itemIndex].IsUpgraded = true;
            UpgradeBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            UpgradeBtn.interactable = false;
            UpgradeBtn.transform.GetChild(0).GetComponent<Text>().text = "UPGRADED";
            UpgradeBtn.GetComponent<Image>().color = Color.black;
            SetCoinsUI();
        }
        else
        {
            NoCoinsAnim.SetTrigger("NoCoins");
            Debug.Log("You don't have enough coins!!");
        }
    }

    void SetCoinsUI()
    {
        CoinsText.text = GameHandler.Instance.Coins.ToString();
    }

    public void Back()
    {
        SceneManager.LoadScene("MainPage");
    }

   /*void Update()
    {
        Sprite a = 

        rotationEuler += Vector3.forward * 30 * Time.deltaTime; //increment 30 degrees every second
        UpgradeSpellsList[0].stransform.rotation = Quaternion.Euler(rotationEuler);
    }
    */
    }
