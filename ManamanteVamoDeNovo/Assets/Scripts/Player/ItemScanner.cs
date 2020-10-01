using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScanner : MonoBehaviour
{

    public GroundItem item;

    public DiaryController diaryController;
    
    public bool canScan = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canScan && Input.GetKeyDown(KeyCode.R))
        {
            diaryController.ScannedItem(item.itemObject);
        }
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
