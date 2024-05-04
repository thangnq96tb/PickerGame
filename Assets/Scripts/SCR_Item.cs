using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SCR_Item : MonoBehaviour
{
    [SerializeField]
    public Image m_ImgReward;
    [SerializeField]
    public TextMeshProUGUI m_Point;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        GameManager.Instance.AddPoint(ShowItem());
    }    

    public int ShowItem()
    {
        m_ImgReward.gameObject.SetActive(true);
        int point = Random.Range(1, 100);
        m_Point.text = point + "K";
        gameObject.GetComponent<Button>().interactable = false;
        return point;
    }    

    public Vector2 GetSize()
    {
        return gameObject.GetComponent<RectTransform>().rect.size;
    }    
}
