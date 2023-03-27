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
        
    }


    public void UpdateSlot(Sprite sprite, string str)
    {

        text.text = str;
        image.sprite = sprite;
    }
}
