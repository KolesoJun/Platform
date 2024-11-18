using UnityEngine;

public class DrawAreaVampirism : MonoBehaviour
{
    [SerializeField] private AbylityVampir _abylity;
    [SerializeField] private AreaActionVampire _area;
    [SerializeField] private SpriteRenderer _image;

    private void Awake()
    {
        _image.enabled = false;
    }

    private void OnEnable()
    {
        _abylity.CanDrawed += Draw;
    }

    private void OnDisable()
    {
        _abylity.CanDrawed -= Draw;
    }

    private void Draw(bool isWork)
    {
        _image.enabled = isWork;
        _area.enabled = isWork;
    }
}
