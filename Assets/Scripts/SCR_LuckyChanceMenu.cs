using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SCR_LuckyChanceMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TotalPoint;
    [SerializeField] Button[] m_MysteryBoxes;
    [SerializeField] GameObject[] m_OpenedBoxes;
    [SerializeField] GameObject m_MysteryBox;
    [SerializeField] GameObject m_OpenedBox;
    [SerializeField] TextMeshProUGUI m_PickTxt;
    [SerializeField] GameObject m_Statistic;
    [SerializeField] TextMeshProUGUI m_highestPointTXT;
    [SerializeField] TextMeshProUGUI m_lowestPointTXT;
    [SerializeField] TextMeshProUGUI m_bestTimeTXT;

    [SerializeField]
    Button m_HomeBTN;
    
    private Dictionary<Button, Chance> m_listChances;
    private SCR_GameConfig m_GameConfig;
    private int totalPoint;
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
        m_Statistic.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenBox(int index)
    {
        SoundManager.Instance.PlaySoundEffect(SoundManager.SFX.CLICK);
        m_PickTxt.gameObject.SetActive(false);
        m_MysteryBox.gameObject.SetActive(false);
        m_OpenedBox.gameObject.SetActive(true);

        m_OpenedBoxes[index].GetComponentInChildren<Image>().color = new Color(255, 255, 255, 255);

        for(int i = 0; i < m_OpenedBoxes.Length; i++)
        {
            m_OpenedBoxes[i].GetComponentsInChildren<Image>()[1].sprite = m_listChances.ElementAt(i).Value.m_Image;
            if(i == index)
            {
                totalPoint = (PlayerPrefs.GetInt("TotalPoint") * m_listChances.ElementAt(i).Value.value);
                if(totalPoint > PlayerPrefs.GetInt("HighestPoint"))
                {
                    PlayerPrefs.SetInt("HighestPoint", totalPoint);
                }    

                if(PlayerPrefs.GetInt("LowestPoint") == 0)
                {
                    PlayerPrefs.SetInt("LowestPoint", totalPoint);
                }    
                else if(totalPoint < PlayerPrefs.GetInt("LowestPoint"))
                {
                    PlayerPrefs.SetInt("LowestPoint", totalPoint);
                }

                m_TotalPoint.text = totalPoint.ToString();
            }    
        }

        StartCoroutine(ShowStatistic());
    }    

    IEnumerator ShowStatistic()
    {
        yield return new WaitForSeconds(2);
        SoundManager.Instance.PlaySoundEffect(SoundManager.SFX.OUTRO);
        m_Statistic.gameObject.SetActive(true);
        int highestPoint = PlayerPrefs.GetInt("HighestPoint");
        int lowestPoint = PlayerPrefs.GetInt("LowestPoint");
        int bestTime = PlayerPrefs.GetInt("BestTime");
        m_highestPointTXT.text = highestPoint == 0 ? "NA" : PlayerPrefs.GetInt("HighestPoint").ToString();
        m_lowestPointTXT.text = lowestPoint == 0 ? "NA" : PlayerPrefs.GetInt("LowestPoint").ToString();
        m_bestTimeTXT.text = bestTime == 0 ? "NA" : PlayerPrefs.GetInt("BestTime").ToString();

        m_HomeBTN.onClick.AddListener(delegate { SceneManager.LoadScene("MainMenu"); });
    }    
}
