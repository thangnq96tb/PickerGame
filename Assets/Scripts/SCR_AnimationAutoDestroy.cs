using UnityEngine;

public class SCR_AnimationAutoDestroy : MonoBehaviour
{
    private float time;
    // Start is called before the first frame update
    private void Start()
    {
        time = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, time);
    }
}
