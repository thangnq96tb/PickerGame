using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI m_TotalPoint;
    [SerializeField]
    public static Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Sprite GetRandomSprite()
    {
        int rand = Random.Range(0, sprites.Length);
        return sprites[rand];
    }    
}
