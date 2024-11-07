using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonChangeColor : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private float _percent;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _colorText;

    private Coroutine _coroutine;

   public void Action()
   {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Dissolve());
   }

    private IEnumerator Dissolve()
    {
        WaitForSeconds wait = new WaitForSeconds(_time);

        while (_image.color.a != 0)
        {
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, Mathf.Lerp(_image.color.a, 0f, _percent*Time.deltaTime));
            _colorText.color = new Color(_image.color.r, _image.color.g, _image.color.b, Mathf.Lerp(_image.color.a, 0f, _percent * Time.deltaTime));
            yield return wait;
        }
    }
}
