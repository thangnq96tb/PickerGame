using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BoardConfig
{
    public int numberCol;
    public int numberRow;
}

[Serializable]
public class PointConfig
{
    public int min;
    public int max;
}

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 1)]
public class SCR_GameConfig : ScriptableObject
{
    public BoardConfig m_BoardConfig;
    public PointConfig m_PointConfig;

    public int m_NumberPick;
}