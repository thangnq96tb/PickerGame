using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField]
    TextMeshProUGUI m_TotalPoint;
    [SerializeField]
    public static Sprite[] sprites;
    [SerializeField]
    SCR_Item m_ItemPfb;
    [SerializeField]
    int m_BoardCol, m_BoardRow;
    [SerializeField]
    GridLayoutGroup m_Board;

    private float m_BoardWidth, m_BoardHeight;
    private int m_point = 0;

    private void Start()
    {
        m_BoardWidth = m_Board.GetComponent<RectTransform>().rect.width;
        m_BoardHeight = m_Board.GetComponent<RectTransform>().rect.height;

        m_TotalPoint.text = m_point.ToString();
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
    }
    public void GenerateBoard()
    {
        foreach (Transform item in m_Board.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 0; i < m_BoardCol * m_BoardRow; i++)
        {
            Instantiate(m_ItemPfb, m_Board.transform);
        }
    }

    public void AddPoint(int amount)
    {
        m_point += amount;
        m_TotalPoint.text = m_point.ToString();
    }    
}
