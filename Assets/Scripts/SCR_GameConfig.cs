using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BoardConfig
{
    public int numberCol;
    public int numberRow;
    public int min;
    public int max;
}

[Serializable]
public class PointConfig
{
    public int min;
    public int max;
}

[Serializable]
public class Chance
{
    public Sprite m_Image;
    public int value;
}

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 1)]
public class SCR_GameConfig : ScriptableObject
{
    public BoardConfig m_BoardConfig;
    public PointConfig m_PointConfig;
    public List<Chance> m_ListChance;
    public int m_NumberPick;
}