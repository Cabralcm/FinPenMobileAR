using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class ColorChangeScript : MonoBehaviour
{

    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
   //     if (Input.GetButtonUp("Fire1"))
        if(Input.touchCount == 2)
        {
            rend.material.SetColor("_Color", Random.ColorHSV());
        }
    }
}
