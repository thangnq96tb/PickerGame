using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SCR_MainMenu : MonoBehaviour
{
    [SerializeField] private Button m_GoBtn;
    [SerializeField] private Button m_ClearDataBtn;
    [SerializeField] private Button m_IncreaseColBtn;
    [SerializeField] private Button m_DecreaseColBtn;
    [SerializeField] private Button m_IncreaseRowBtn;
    [SerializeField] private Button m_DecreaseRowBtn;

    [SerializeField] private TextMeshProUGUI m_NumberColTxt;
    [SerializeField] private TextMeshProUGUI m_NumberRowTxt;

    [SerializeField] TextMeshProUGUI m_highestPointTXT;
    [SerializeField] TextMeshProUGUI m_lowestPointTXT;
    [SerializeField] TextMeshProUGUI m_bestTimeTXT;

    private SCR_GameConfig m_GameConfig;
    private int numberCol, numberRow;

    // Start is called before the first frame update
    void Start()
    {
        m_GameConfig = Resources.Load<SCR_GameConfig>("GameConfig");
        m_GoBtn.onClick.AddListener(delegate { OnGoButtonClicked(); } );
        m_ClearDataBtn.onClick.AddListener(delegate { PlayerPrefs.DeleteAll(); UpdateStatistic(); });
        m_IncreaseColBtn.onClick.AddListener(delegate { ChangeNumberCol(1); });
        m_IncreaseRowBtn.onClick.AddListener(delegate { ChangeNumberRow(1); });
        m_DecreaseColBtn.onClick.AddListener(delegate { ChangeNumberCol(-1); });
        m_DecreaseRowBtn.onClick.AddListener(delegate { ChangeNumberRow(-1); });

        numberCol = m_GameConfig.m_BoardConfig.numberCol;
        numberRow = m_GameConfig.m_BoardConfig.numberRow;

        UpdateUI();
        UpdateStatistic();
    }

    public void OnGoButtonClicked()
    {
        PlayerPrefs.SetInt("NumberCol", numberCol);
        PlayerPrefs.SetInt("NumberRow", numberRow);

        SceneManager.LoadScene("GamePlay");
    }

    public void ChangeNumberCol(int amount)
    {
        numberCol += amount;
        numberCol = numberCol < m_GameConfig.m_BoardConfig.min ? m_GameConfig.m_BoardConfig.min : numberCol;
        numberCol = numberCol > m_GameConfig.m_BoardConfig.max ? m_GameConfig.m_BoardConfig.max : numberCol;
        UpdateUI();
    }

    public void ChangeNumberRow(int amount)
    {
        numberRow += amount;
        numberRow = numberRow < m_GameConfig.m_BoardConfig.min ? m_GameConfig.m_BoardConfig.min : numberRow;
        numberRow = numberRow > m_GameConfig.m_BoardConfig.max ? m_GameConfig.m_BoardConfig.max : numberRow;
        UpdateUI();
    }

    public void UpdateUI()
    {
        m_NumberColTxt.text = numberCol.ToString();
        m_NumberRowTxt.text = numberRow.ToString();
    }

    public void UpdateStatistic()
    {
        int highestPoint = PlayerPrefs.GetInt("HighestPoint");
        int lowestPoint = PlayerPrefs.GetInt("LowestPoint");
        int bestTime = PlayerPrefs.GetInt("BestTime");
        m_highestPointTXT.text = highestPoint == 0 ? "NA" : PlayerPrefs.GetInt("HighestPoint").ToString();
        m_lowestPointTXT.text = lowestPoint == 0 ? "NA" : PlayerPrefs.GetInt("LowestPoint").ToString();
        m_bestTimeTXT.text = bestTime == 0 ? "NA" : PlayerPrefs.GetInt("BestTime").ToString();
    }    
}
