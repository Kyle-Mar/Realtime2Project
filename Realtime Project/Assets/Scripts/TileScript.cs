using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public bool isFree = true;
    public bool lookedAt = false;
    private bool defaultColor = true;

    public Material greenMAT;
    private Material defaultMAT;

    // Start is called before the first frame update
    void Start()
    {
        defaultMAT = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (lookedAt)
        {
            if (defaultColor)
            {
                GetComponent<MeshRenderer>().material = greenMAT;
                defaultColor = false;
            }
        }
        else
        {
            if (!defaultColor)
            {
                GetComponent<MeshRenderer>().material = defaultMAT;
                defaultColor = true;
            }
        }

        // Default
        lookedAt = false;
    }
}
