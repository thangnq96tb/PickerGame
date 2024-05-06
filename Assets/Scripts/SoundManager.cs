using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviourSingleton<SoundManager>
{
    [SerializeField] private AudioSource m_EffectsSource;
    [SerializeField] private AudioSource m_MusicSource;

    private SCR_GameConfig m_GameConfig;

    // Start is called before the first frame update
    void Start()
    {
        m_GameConfig = Resources.Load<SCR_GameConfig>("GameConfig");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySoundEffect(SFX sfx)
    {
        m_EffectsSource.PlayOneShot(m_GameConfig.m_SoundInfo.Where(x => x.m_id == sfx).FirstOrDefault().m_Audio);
    }    

    public void PlayMusic()
    {
        m_MusicSource.clip = m_GameConfig.m_SoundInfo.Where(x => x.m_id == SFX.BG_MUSIC).FirstOrDefault().m_Audio;
        m_MusicSource.loop = true;
        m_MusicSource.Play();
    }    

    public enum SFX
    {
        BG_MUSIC,
        CLICK,
        INTRO,
        OUTRO
    }    
}
