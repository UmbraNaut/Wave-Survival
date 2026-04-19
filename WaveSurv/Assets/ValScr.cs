using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ValScr : MonoBehaviour
{
    public Slider silder;
    public TextMeshProUGUI thistxt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int toint = (int)(silder.value + 0.5);
        thistxt.text = toint.ToString();
    }
}
