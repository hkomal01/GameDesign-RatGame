using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameInventory : MonoBehaviour {
      public GameObject InventoryMenu;
      //public GameObject CraftMenu;
      public bool InvIsOpen = false;

      //5 Inventory Items:
      public static bool item1bool = false;
      public static bool item2bool = false;
      public static bool item3bool = false;
      public static bool item4bool = false;
      public static bool item5bool = false;

      public static int item1num = 0;
      public static int item2num = 0;
      public static int item3num = 0;
      public static int item4num = 0;
      public static int item5num = 0;
      //public static int coins = 0;

      public GameObject item1image;
      public GameObject item2image;
      public GameObject item3image;
      public GameObject item4image;
      public GameObject item5image;
      //public GameObject coinText;

      // Item number text variables. Comment out if each item is unique (1/2).
      public Text item1Text;
      public Text item2Text;
      public Text item3Text;
      public Text item4Text;
      public Text item5Text;

      // Crafting buttons. Uncomment and add for each button:
      // public GameObject buttonCraft1; // weapon1 creation
 
      void Start(){
            InventoryMenu.SetActive(true);
            //CraftMenu.SetActive(false);
            InventoryDisplay();
      }

      void InventoryDisplay(){
            if (item1bool == true) {item1image.SetActive(true);} else {item1image.SetActive(false);}
            if (item2bool == true) {item2image.SetActive(true);} else {item2image.SetActive(false);}
            if (item3bool == true) {item3image.SetActive(true);} else {item3image.SetActive(false);}
            if (item4bool == true) {item4image.SetActive(true);} else {item4image.SetActive(false);}
            if (item5bool == true) {item5image.SetActive(true);} else {item5image.SetActive(false);}

            //Text coinTextB = coinText.GetComponent<Text>();
            //coinTextB.text = ("COINS: " + coins);

            // Item number updates. Comment out if each item is unique (2/2).
            Text item1TextB = item1Text.GetComponent<Text>();
            item1TextB.text = ("" + item1num);

            Text item2TextB = item2Text.GetComponent<Text>();
            item2TextB.text = ("" + item2num);

            Text item3TextB = item3Text.GetComponent<Text>();
            item3TextB.text = ("" + item3num);

            Text item4TextB = item4Text.GetComponent<Text>();
            item4TextB.text = ("" + item4num);

            Text item5TextB = item5Text.GetComponent<Text>();
            item5TextB.text = ("" + item5num);
      }

      public void InventoryAdd(string item){
            string foundItemName = item;
            if (foundItemName == "item1") {item1bool = true; item1num ++;}
            else if (foundItemName == "item2") {item2bool = true; item2num ++;}
            else if (foundItemName == "item3") {item3bool = true; item3num ++;}
            else if (foundItemName == "item4") {item4bool = true; item4num ++;}
            else if (foundItemName == "item5") {item5bool = true; item5num ++;}
            else { Debug.Log("This item does not exist to be added"); }
            InventoryDisplay();

            if (!InvIsOpen){
                  OpenCloseInventory();
            }
      }

      public void InventoryRemove(string item, int num){
            string itemRemove = item;
            if (itemRemove == "item1") {
                  item1num -= num;
                  if (item1num <= 0) { item1bool =false; }
                  // Add any other intended effects: new item crafted, speed boost, slow time, etc
             }
            else if (itemRemove == "item2") {
                  item2num -= num;
                  if (item2num <= 0) { item2bool =false; }
                  // Add any other intended effects
             }
            else if (itemRemove == "item3") {
                  item3num -= num;
                  if (item3num <= 0) { item3bool =false; }
                    // Add any other intended effects
            }
            else if (itemRemove == "item4") {
                  item4num -= num;
                  if (item4num <= 0) { item4bool =false; }
                    // Add any other intended effects
            }
            else if (itemRemove == "item5") {
                  item5num -= num;
                  if (item5num <= 0) { item5bool =false; }
                    // Add any other intended effects
            }
            else { Debug.Log("This item does not exist to be removed"); }
            InventoryDisplay();
      }

      //public void CoinChange(int amount){
            //coins +=amount;
            //InventoryDisplay();
      //}

      // Open and Close the Inventory. Use this function on a button next to the inventory bar.
      public void OpenCloseInventory(){
            if (InvIsOpen){ InventoryMenu.SetActive(false); }
            else { InventoryMenu.SetActive(true); }
            InvIsOpen = !InvIsOpen;
      }

      //Open and Close the Cookbook
      //public void OpenCraftBook(){CraftMenu.SetActive(true);}
      //public void CloseCraftBook(){CraftMenu.SetActive(false);}

      // Reset all static inventory values on game restart.
      public void ResetAllInventory(){
            item1bool = false;
            item2bool = false;
            item3bool = false;
            item4bool = false;
            item5bool = false;

            item1num = 0; // object name
            item2num = 0; // object name
            item3num = 0; // object name
            item4num = 0; // object name
            item5num = 0; // object name
      }

}