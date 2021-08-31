using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShop
{
    [System.Serializable]
    public class ShopData
    {
        public int SelectedIndex;
        public StoreItem[] storeitem;
    }

    [System.Serializable]
    public class StoreItem
    {
        public string item_Name;
        public bool is_Bought;
        public int cost;
    }

    public class CubeInfo
    {
        public int cube_cost;

    }


}


