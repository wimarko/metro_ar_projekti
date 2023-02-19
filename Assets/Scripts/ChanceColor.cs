using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceColor : MonoBehaviour
{

    public Material colorMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor() { 
        colorMaterial.color = new Color(
            Random.Range(0f,1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            1
            );
    }
}
