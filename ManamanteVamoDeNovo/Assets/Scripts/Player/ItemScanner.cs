using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemScanner : MonoBehaviour
{

    public GroundItem item;

    public DiaryInfoController diaryInfoController;
    
    public bool canScan = false;

    public bool isScanning = false;

    public TMP_Text scanFeedbackText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canScan && Input.GetKeyDown(KeyCode.R) && !isScanning)
        {
            isScanning = true;
            item.scanEffect.SetActive(true);
            StartCoroutine(scanEffectTime());
            switch (item.itemObject.type)
            {
                case ItemType.Crafting:
                    if(item.itemObject.craftingItemType == CraftingItemType.Fruta)
                    {
                        diaryInfoController.SetInfo(item.itemObject.name, item.itemObject.uiDisplay, item.itemObject.description, "Coletaveis", "Fruta");
                    }
                    else if(item.itemObject.craftingItemType == CraftingItemType.Flor || item.itemObject.craftingItemType == CraftingItemType.Folha)
                    {
                        diaryInfoController.SetInfo(item.itemObject.name, item.itemObject.uiDisplay, item.itemObject.description, "Coletaveis", "Flor");
                    }
                    else if(item.itemObject.craftingItemType == CraftingItemType.Cogumelo)
                    {
                        diaryInfoController.SetInfo(item.itemObject.name, item.itemObject.uiDisplay, item.itemObject.description, "Coletaveis", "Cogumelo");
                    }
                    else
                    {
                        diaryInfoController.SetInfo(item.itemObject.name, item.itemObject.uiDisplay, item.itemObject.description, "Coletaveis", "Partes");
                    }
                    break;
                case ItemType.Equipment:
                    break;
                case ItemType.Potion:
                    diaryInfoController.SetInfo(item.itemObject.name, item.itemObject.uiDisplay, item.itemObject.description, "Coletaveis", "Pocao");
                    break;
            }
                
        }
    }

    IEnumerator scanEffectTime()
    {
        yield return new WaitForSeconds(3.2f);
        item.scanEffect.SetActive(false);
        isScanning = false;
        scanFeedbackText.gameObject.SetActive(true);
        scanFeedbackText.text = item.itemObject.name;
        StartCoroutine(scanFeedBackText());
    }

    IEnumerator scanFeedBackText()
    {
        yield return new WaitForSeconds(3f);
        scanFeedbackText.gameObject.SetActive(false);
        scanFeedbackText.text = "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            canScan = true;
            item = collision.gameObject.GetComponent<GroundItem>();
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "item")
        {
            canScan = false;
        }
    }
}
