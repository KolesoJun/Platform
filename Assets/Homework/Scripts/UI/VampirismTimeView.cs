using UnityEngine;
using TMPro;

public class VampirismTimeView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private AbylityVampir _abylityVampir;

    private void OnEnable()
    {
        _abylityVampir.WorkedTime += Draw;
    }

    private void OnDisable()
    {
        _abylityVampir.WorkedTime -= Draw;
    }

    private void Draw(float value)
    {
        _text.text = value.ToString();
    }
}
