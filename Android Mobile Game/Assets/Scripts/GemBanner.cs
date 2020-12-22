using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemBanner : MonoBehaviour
{
    private Text greenGemText;
    private Text blueGemText;
    private Text purpleGemText;

    private void Start()
    {
        greenGemText = gameObject.transform.Find("GreenGems").GetComponent<Text>();
        blueGemText = gameObject.transform.Find("BlueGems").GetComponent<Text>();
        purpleGemText = gameObject.transform.Find("PurpleGems").GetComponent<Text>();
    }

    private void Update()
    {
        greenGemText.text = GemValues.greenGem.ToString(); 
        blueGemText.text = GemValues.blueGem.ToString();
        purpleGemText.text = GemValues.purpleGem.ToString();

    }
}
