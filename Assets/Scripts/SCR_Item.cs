using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum State
{
    MYSTERY,
    SELECTED, 
    UNSELECTED
}
public class SCR_Item : MonoBehaviour
{
    [SerializeField] public Image m_ImgReward;
    [SerializeField] public TextMeshProUGUI m_Point;
    [SerializeField] public GameObject m_Selected;
    [SerializeField] public GameObject m_UnSelected;

    public State m_State;

    public int point { private set; get; }

    // Start is called before the first frame update
    void Start()
    {
        m_State = State.MYSTERY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUp(int amount)
    {
        point = amount;
    }    

    public void OnClick()
    {
        GameManager.Instance.AddPoint(ShowItem());
        GameManager.Instance.UpdatePick();
        m_State = State.SELECTED;
        UpdateUI();
    }    

    public int ShowItem()
    {
        m_State = State.UNSELECTED;
        UpdateUI();
        
        m_ImgReward.gameObject.SetActive(true);
        m_Point.text = point.ToString();
        gameObject.GetComponent<Button>().interactable = false;
        return point;
    }    

    public void UpdateUI()
    {
        m_Selected.SetActive(m_State == State.SELECTED);
        m_UnSelected.SetActive(m_State == State.UNSELECTED);
    }    

    public Vector2 GetSize()
    {
        return gameObject.GetComponent<RectTransform>().rect.size;
    }    
}
