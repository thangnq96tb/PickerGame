using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

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

[Serializable]
public class SoundInfo
{
    public SFX m_id;
    public AudioClip m_Audio;
}

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 1)]
public class SCR_GameConfig : ScriptableObject
{
    public BoardConfig m_BoardConfig;
    public PointConfig m_PointConfig;
    public List<Chance> m_ListChance;
    public List<SoundInfo> m_SoundInfo;
    public int m_NumberPick;
}