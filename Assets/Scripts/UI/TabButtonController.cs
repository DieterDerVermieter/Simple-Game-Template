using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabButtonController : MonoBehaviour
{
    Button m_button;


    [SerializeField] GameObject m_frame;


    public bool IsSelected { get; private set; }

    public Action<int> OnClick;


    public int TabIndex;


    private void Awake()
    {
        m_button = GetComponent<Button>();

        m_button.onClick.AddListener(ButtonOnClick);
    }


    private void OnEnable()
    {
        m_button.interactable = true;
    }

    private void OnDisable()
    {
        m_button.interactable = false;
    }


    private void ButtonOnClick()
    {
        OnClick?.Invoke(TabIndex);
    }


    public void Select()
    {
        IsSelected = true;
        m_frame.SetActive(true);
    }

    public void Deselect()
    {
        IsSelected = false;
        m_frame.SetActive(false);
    }
}
