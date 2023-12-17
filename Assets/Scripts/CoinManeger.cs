using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManeger : MonoBehaviour
{
    // Start is called before the first frame update
    public int CoinCount=0;
    public Text coinText;
    void Start()
    {
        CoinCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "x "+ CoinCount.ToString();
    }
}
