
using UnityEngine;

public class dorrSlider : MonoBehaviour
{

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    [ContextMenu(itemName:"Open")]
    public void Open()
    {
        _animator.SetTrigger(name: "Open");
    }

}
