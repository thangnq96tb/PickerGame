using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SCR_LuckyChanceMenu : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI m_TotalPoint;
    [SerializeField]
    Button[] m_MysteryBoxes;
    [SerializeField]
    GameObject[] m_OpenedBoxes;
    [SerializeField]
    GameObject m_MysteryBox;
    [SerializeField]
    GameObject m_OpenedBox;
    [SerializeField]
    TextMeshProUGUI m_PickTxt;

    private Dictionary<Button, Chance> m_listChances;
    private SCR_GameConfig m_GameConfig;

    // Start is called before the first frame update
    void Start()
    {
        m_GameConfig = Resources.Load<SCR_GameConfig>("GameConfig");
        m_TotalPoint.text = PlayerPrefs.GetInt("TotalPoint").ToString();

        m_listChances = new Dictionary<Button, Chance>();
        System.Random random = new System.Random();
        var shuffledChances = m_GameConfig.m_ListChance.OrderBy(x => random.Next()).ToList();

        for (int i = 0; i < m_MysteryBoxes.Length; i++)
        {
            int currentIndex = i;
            m_MysteryBoxes[i].onClick.AddListener(delegate { OpenBox(currentIndex); });
            m_listChances.Add(m_MysteryBoxes[i], shuffledChances[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenBox(int index)
    {
        m_PickTxt.gameObject.SetActive(false);
        m_MysteryBox.gameObject.SetActive(false);
        m_OpenedBox.gameObject.SetActive(true);

        m_OpenedBoxes[index].GetComponentInChildren<Image>().color = new Color(255, 255, 255, 255);

        for(int i = 0; i < m_OpenedBoxes.Length; i++)
        {
            m_OpenedBoxes[i].GetComponentsInChildren<Image>()[1].sprite = m_listChances.ElementAt(i).Value.m_Image;
            if(i == index)
            {
                m_TotalPoint.text = (PlayerPrefs.GetInt("TotalPoint") * m_listChances.ElementAt(i).Value.value).ToString();
            }    
        }    
    }    
}
