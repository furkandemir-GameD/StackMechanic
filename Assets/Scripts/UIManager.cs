using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(CanvasScaler))]
[RequireComponent(typeof(GraphicRaycaster))]
[RequireComponent(typeof(RectTransform))]


[System.Serializable]
public class UIPanel
{
    public CanvasGroup CanvasGroup;
    public GameManager.GameStates GameStates;
}


public class UIManager : MonoBehaviour
{
    private static UIManager _uiManager;
    public static UIManager uiManager { get { return _uiManager; } private set { } }

    [Header("UI Compenents")]
    [SerializeField]
    private Button nextButton;

    [SerializeField]
    private Button tryButton;

    [SerializeField]
    private Button startButton;

    [SerializeField] private List<UIPanel> uIPanels;
    private UIPanel currentPanel;

    private void OnEnable()
    {
        GameManager.OnGameStateChange += ChangeUI;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChange = ChangeUI;

    }

    private void ChangeUI(GameManager.GameStates state)
    {
        if(currentPanel != null)
        {
            currentPanel.CanvasGroup.alpha = 0f;
        }
        var newPanel = uIPanels.Find(x => x.GameStates == state);
        newPanel.CanvasGroup.alpha = 1f;

        currentPanel = newPanel;
    }
    private void Start()
    {
        ActiveControl(1);
    }
    public void ActiveControl(int statment)
    {
        switch (statment)
        {
            case 3:
                tryButton.gameObject.SetActive(true);
                break;
            case 2:
                nextButton.gameObject.SetActive(true);
                break;
            case 1:
                startButton.gameObject.SetActive(true);
                break;
            default:
                Debug.LogError("UI Manager Eroor!! ");
                break;
        }
    }
}
