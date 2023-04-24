using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class Slot : MonoBehaviour
{
    public Image image;
    public TMPro.TMP_Text text;
    public float cost;
    public bool available = true;
    // Start is called before the first frame update
    void Awake()
    {
        image = gameObject.GetComponentsInChildren<Image>()
            .Where(x => x.transform.parent != transform.parent).ToList()[0];
        text = gameObject.GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // THIS SUCKS BUT I'M LAZY
        if (!available)
        {
            text.text = "PURCHASED";
            image.color = new Color(image.color.r,image.color.g, image.color.b, 0);
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        }
    }


    public void UpdateSlot(Sprite sprite, string str, float newCost)
    {
        text.text = str + " Cost: " + newCost.ToString();
        image.sprite = sprite;
        cost = newCost;
        available = true;
    }
}
