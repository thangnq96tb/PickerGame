using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SCR_MainMenu : MonoBehaviour
{
    [SerializeField] private Button m_GoBtn;
    [SerializeField] private Button m_IncreaseColBtn;
    [SerializeField] private Button m_DecreaseColBtn;
    [SerializeField] private Button m_IncreaseRowBtn;
    [SerializeField] private Button m_DecreaseRowBtn;

    [SerializeField] private TextMeshProUGUI m_NumberColTxt;
    [SerializeField] private TextMeshProUGUI m_NumberRowTxt;

    private SCR_GameConfig m_GameConfig;
    private int numberCol, numberRow;

    // Start is called before the first frame update
    void Start()
    {
        m_GameConfig = Resources.Load<SCR_GameConfig>("GameConfig");
        m_GoBtn.onClick.AddListener(delegate { OnGoButtonClicked(); } );

        m_IncreaseColBtn.onClick.AddListener(delegate { ChangeNumberCol(1); });
        m_IncreaseRowBtn.onClick.AddListener(delegate { ChangeNumberRow(1); });
        m_DecreaseColBtn.onClick.AddListener(delegate { ChangeNumberCol(-1); });
        m_DecreaseRowBtn.onClick.AddListener(delegate { ChangeNumberRow(-1); });

        numberCol = m_GameConfig.m_BoardConfig.numberCol;
        numberRow = m_GameConfig.m_BoardConfig.numberRow;

        UpdateUI();
    }

    public void OnGoButtonClicked()
    {
        m_GameConfig.m_BoardConfig.numberCol = numberCol;
        m_GameConfig.m_BoardConfig.numberRow = numberRow;

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
}
