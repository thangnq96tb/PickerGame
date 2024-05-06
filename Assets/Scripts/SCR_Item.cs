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
    [SerializeField] public GameObject m_VFXItemSelect;

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
        StartCoroutine(ChooseItem());
    }    
    
    IEnumerator ChooseItem()
    {
        m_VFXItemSelect.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().rect.width, gameObject.GetComponent<RectTransform>().rect.height);
        Instantiate(m_VFXItemSelect, transform);
        SoundManager.Instance.PlaySoundEffect(SoundManager.SFX.CLICK);
        GameManager.Instance.AddPoint(ShowItem());
        m_State = State.SELECTED;
        GameManager.Instance.UpdatePick();
        yield return new WaitForSeconds(0.6f);
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
