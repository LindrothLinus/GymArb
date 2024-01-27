using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveManeger : MonoBehaviour
{
    // Start is called before the first frame update
    public int LifeCount=0;
    public Text LifeText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LifeText.text = "x "+ LifeCount.ToString();
    }
}
