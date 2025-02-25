using UnityEngine;
using UnityEngine.UI;

public class ImageFader : MonoBehaviour
{
    [SerializeField] private Image _named;
    [SerializeField] private Image _anonymus;

    private void Start()
    {
        StartCoroutine(_named.AnimateFadeOut(3f, CallbackHandler));
        StartCoroutine(_anonymus.AnimateFadeOut(3f, () => _anonymus.gameObject.SetActive(false)));
    }

    private void CallbackHandler()
    {
        _named.gameObject.SetActive(false);
    }
}
