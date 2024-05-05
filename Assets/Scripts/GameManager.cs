using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField]
    SCR_Item m_ItemPfb;

    [Header("TOP BAR")]
    [SerializeField]
    TextMeshProUGUI m_TotalPoint;
    [SerializeField]
    TextMeshProUGUI m_MaxPointCanEarn;
    [SerializeField]
    public static Sprite[] sprites;
    [SerializeField]
    GridLayoutGroup m_Board;
    [SerializeField]
    TextMeshProUGUI m_PickTxt;

    private int m_BoardCol, m_BoardRow;
    private float m_BoardWidth, m_BoardHeight;
    private int totalPoint = 0;
    private int m_numberPick;
    private List<SCR_Item> m_listItem;

    private SCR_GameConfig m_GameConfig;

    private void Start()
    {
        m_GameConfig = Resources.Load<SCR_GameConfig>("GameConfig");
        m_BoardCol = m_GameConfig.m_BoardConfig.numberCol;
        m_BoardRow = m_GameConfig.m_BoardConfig.numberRow;
        m_numberPick = m_GameConfig.m_NumberPick;

        m_listItem = new List<SCR_Item>();

        m_BoardWidth = m_Board.GetComponent<RectTransform>().rect.width;
        m_BoardHeight = m_Board.GetComponent<RectTransform>().rect.height;

        m_TotalPoint.text = totalPoint.ToString();
        m_Board.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        m_Board.constraintCount = m_BoardCol;

        float totalWidth = (m_BoardCol - 1) * m_Board.spacing.x + m_BoardCol * m_ItemPfb.GetSize().x;
        float totalHeight = (m_BoardRow - 1) * m_Board.spacing.y + m_BoardRow * m_ItemPfb.GetSize().y;

        float scaleW = m_BoardWidth / totalWidth;
        float scaleH = m_BoardHeight / totalHeight;

        float scale = scaleW > scaleH ? scaleH : scaleW;

        if (scale < 1)
        {
            m_Board.cellSize = new Vector2(m_ItemPfb.GetSize().x * scale, m_ItemPfb.GetSize().y * scale);
            m_Board.spacing *= scale;
        }

        GenerateBoard();
        UpdatePick();
    }
    public void GenerateBoard()
    {
        m_listItem.Clear();
        foreach (Transform item in m_Board.transform)
        {
            Destroy(item.gameObject);

        }

        int totalItem = m_BoardCol * m_BoardRow;

        for (int i = 0; i < totalItem; i++)
        {
            SCR_Item item = Instantiate(m_ItemPfb, m_Board.transform);
            int randomPoint = Random.Range(m_GameConfig.m_PointConfig.min, m_GameConfig.m_PointConfig.max / totalItem);
            item.SetUp(randomPoint);
            m_listItem.Add(item);
        }
        m_numberPick++;
    }

    public void AddPoint(int amount)
    {
        totalPoint += amount;
        m_TotalPoint.text = totalPoint.ToString();
        PlayerPrefs.SetInt("TotalPoint", totalPoint);
    }    

    public void UpdatePick()
    {
        m_numberPick--;
        if(m_numberPick > 1)
        {
            m_PickTxt.text = $"{m_numberPick} picks!";
            m_MaxPointCanEarn.text = MaxPointCanEarn().ToString();
        }
        else if(m_numberPick == 1)
        {
            m_PickTxt.text = "1 pick!";
            m_MaxPointCanEarn.text = MaxPointCanEarn().ToString();
        }
        else
        {
            m_PickTxt.gameObject.SetActive(false);
            m_listItem = m_listItem.Where(x => x.m_State == State.MYSTERY).ToList();
            foreach(var item in m_listItem)
            {
                item.ShowItem();
                SceneManager.LoadScene("LuckyChance");
            }    
        } 
    }
    
    public int MaxPointCanEarn()
    {
       return totalPoint + m_listItem.Where(x => x.m_State == State.MYSTERY).OrderByDescending(x => x.point).Take(m_numberPick).Sum(x => x.point);
    }    

    public SCR_GameConfig GetGameConfig()
    {
        return m_GameConfig;
    }    
}
