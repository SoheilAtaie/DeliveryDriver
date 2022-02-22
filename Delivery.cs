using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    bool hasPackage;
    [SerializeField]
    Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField]
    Color32 hasPackageColor = new Color32(236, 83, 83, 255);
    SpriteRenderer spriteRenderer;
 
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("You just had an accident");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up successfully!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject, 1.0f);
        }
        else if ((collision.tag == "Customer") && (hasPackage == true))
        {
            Debug.Log("Package is delivered successfully");
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
    }
}
