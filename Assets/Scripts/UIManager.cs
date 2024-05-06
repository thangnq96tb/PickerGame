using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Button[] buttons;
    private UnityAction soundAction;

    private void Start()
    {
        //buttons = GetComponentsInChildren<Button>(true);
        //foreach (Button button in buttons)
        //{
        //    soundAction = delegate { SoundManager.Instance.PlaySoundEffect(SoundManager.SFX.CLICK); };
        //    button.onClick.RemoveListener(soundAction);
        //    button.onClick.AddListener(soundAction);
            
        //}
    }
}
