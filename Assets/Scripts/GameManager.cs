using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int objects;
    public int victoryLimit = 10;
    [SerializeField] TextMeshProUGUI victoryText;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ObjectPlaced()
    {
        objects++;
        victoryText.text = objects.ToString();
        if (objects >= victoryLimit)
        {
            victoryText.text = "You Won!";
        }
    }

    private void Victory()
    {
        victoryText.enabled= true;
    }
}
