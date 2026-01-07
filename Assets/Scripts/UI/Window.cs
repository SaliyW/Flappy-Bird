using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class Window : MonoBehaviour
{
    private Button _actionButton;
    private CanvasGroup _canvasGroup;
    private readonly int _minAlpha = 0;
    private readonly int _maxAlpha = 1;

    public event UnityAction ButtonClicked;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _actionButton = GetComponentInChildren<Button>();
    }

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Open()
    {
        _canvasGroup.alpha = _maxAlpha;
        _canvasGroup.blocksRaycasts = true;
        _actionButton.interactable = true;
    }

    public void Close()
    {
        _canvasGroup.alpha = _minAlpha;
        _canvasGroup.blocksRaycasts = false;
        _actionButton.interactable = false;
    }

    protected void OnButtonClick()
    {
        ButtonClicked?.Invoke();
    }
}