using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public AudioSource audioSource;
    public static CoinCounter instance;
    public TextMeshProUGUI text;
    int iScore;
    // Start is called before the first frame update

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeNumber(int coinValue)
    {
        iScore += coinValue;
        text.text = "X" + iScore.ToString();
        audioSource.Play();
    }
}
