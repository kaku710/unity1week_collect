using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class InGamePresenter : MonoBehaviour
{
   [SerializeField] private InGameView view;
    private void Start(){
        LoadGame();
        Bind();
    }

    private void LoadGame(){
        GameManager.Instance.SetMoney(0);
        GameManager.Instance.SetPersonProductivity(0);
        GameManager.Instance.SetSecondsProductivity(0);
    }

    private void Bind(){
        GameManager.Instance.Money
            .Subscribe(view.OnMoneyChanged)
            .AddTo(gameObject);
        GameManager.Instance.PersonProductivity
            .Subscribe(view.OnPersonProductivityChanged)
            .AddTo(gameObject);
        GameManager.Instance.SecondsProductivity
            .Subscribe(view.OnSecondsProductivityText)
            .AddTo(gameObject);
    }
}
