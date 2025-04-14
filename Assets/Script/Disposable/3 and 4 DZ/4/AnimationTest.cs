using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    void OnMouseDown()
    {
        using (var animHandler = new AnimatioHandler(_animator))
        {
            Debug.Log("Анимация запущена.");
        }
        
        Debug.Log("Анимация автоматически остановлена после завершения блока using.");
    }

}
