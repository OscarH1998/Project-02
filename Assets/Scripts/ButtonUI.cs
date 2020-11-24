using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    public DeckTester _deckTester;


    public Button _playTopCard;
    public Button _drawCard;

    public GameObject SaveConfirm = null;
    public GameObject LoadConfirm = null;
    public GameObject QuitConfirm = null;


    public void Awake()
    {
        SaveConfirm.SetActive(false);
        LoadConfirm.SetActive(false);
        QuitConfirm.SetActive(false);
    }

    void Start()
    {
        Button btn1 = _playTopCard.GetComponent<Button>();
        Button btn2 = _drawCard.GetComponent<Button>();

        btn1.onClick.AddListener(PlayTopCard);
        btn2.onClick.AddListener(DrawCard);
    }

    void PlayTopCard()
    {
        _deckTester.PlayTopCard();
    }

    void DrawCard()
    {
        _deckTester.Draw();
    }
}