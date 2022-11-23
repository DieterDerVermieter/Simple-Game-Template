using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class QuitPopupController : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button m_noButton;
    [SerializeField] Button m_yesButton;


    TaskCompletionSource<bool> m_tcs = new TaskCompletionSource<bool>();


    private void Awake()
    {
        m_noButton.onClick.AddListener(NoButtonOnClick);
        m_yesButton.onClick.AddListener(YesButtonOnClick);
    }


    private void OnEnable()
    {
        m_noButton.interactable = true;
        m_yesButton.interactable = true;
    }

    private void OnDisable()
    {
        m_noButton.interactable = false;
        m_yesButton.interactable = false;
    }


    private void NoButtonOnClick()
    {
        m_tcs.SetResult(false);
    }

    private void YesButtonOnClick()
    {
        m_tcs.SetResult(true);
    }


    public async Task<bool> DialogueResult()
    {
        return await m_tcs.Task;
    }
}
