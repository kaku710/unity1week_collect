using System.Collections;
using System.Collections.Generic;
using Communication;
using UniRx;
using UnityEngine;

public class InGamePresenter : MonoBehaviour {
    [SerializeField] private InGameView view;
    [SerializeField] private Command command;
    private void Start () {
        LoadGame ();
        Bind ();
        SetEvents ();
    }

    private void Update () {
        SwitchButtonInteractible();
    }

    private void LoadGame () {
        StatusManager.Instance.SetMoney (GameInfo.DEFAULT_MONEY);
        StatusManager.Instance.SetPersonProductivity (GameInfo.DEFAULT_PERSON_PRODUCTIVITY);
        StatusManager.Instance.SetSecondsProductivity (GameInfo.DEFAULT_SECONDS_PRODUCTIVITY);
        StatusManager.Instance.SetStayTime (GameInfo.DEFAULT_STAY_TIME);
    }

    private void Bind () {
        StatusManager.Instance.Money
            .Subscribe (view.OnMoneyChanged)
            .AddTo (gameObject);
        StatusManager.Instance.PersonProductivity
            .Subscribe (view.OnPersonProductivityChanged)
            .AddTo (gameObject);
        StatusManager.Instance.SecondsProductivity
            .Subscribe (view.OnSecondsProductivityChanged)
            .AddTo (gameObject);
        StatusManager.Instance.SnsFollowers
            .Subscribe (view.OnSNSFollowerChanged)
            .AddTo (gameObject);
        StatusManager.Instance.SnsCost
            .Subscribe (view.OnSNSCostChanged)
            .AddTo (gameObject);
        StatusManager.Instance.PartJobCost
            .Subscribe (view.OnPartJobCostChanged)
            .AddTo (gameObject);
        StatusManager.Instance.PartJobCount
            .Subscribe (view.OnPartJobCountChanged)
            .AddTo (gameObject);
        StatusManager.Instance.MenuCost
            .Subscribe (view.OnMenuCostChanged)
            .AddTo (gameObject);
        StatusManager.Instance.MenuCount
            .Subscribe (view.OnMenuCountChanged)
            .AddTo (gameObject);
        StatusManager.Instance.SeatCount
            .Subscribe (view.OnSeatCountChanged)
            .AddTo (gameObject);
        StatusManager.Instance.SeatCost
            .Subscribe (view.OnSeatCostChanged)
            .AddTo (gameObject);
        StatusManager.Instance.MinMoneyPerTap
            .Subscribe(view.OnMinMoneyPerTapChanged)
            .AddTo(gameObject);
        StatusManager.Instance.MaxMoneyPerTap
            .Subscribe(view.OnMaxMoneyPerTapChanged)
            .AddTo(gameObject);
    }

    private void SetEvents () {
        view.snsButton.onClick.AddListener (command.OnSNSButtonClicked);
        view.workButton.onClick.AddListener (command.OnWorkButtonClicked);
        view.employButton.onClick.AddListener (command.OnEmployButtonClicked);
        view.menuExtendButton.onClick.AddListener (command.OnMenuExtendButtonClicked);
        view.seatExtendButton.onClick.AddListener (command.OnSeatExtendButtonClicked);
    }

    private void SwitchButtonInteractible(){
        view.snsButton.interactable = (StatusManager.Instance.Money.Value >= StatusManager.Instance.SnsCost.Value) && (StatusManager.Instance.snsLevel < GameInfo.MAX_SNS_LEVEL - 1) ? true : false;
        view.employButton.interactable = (StatusManager.Instance.Money.Value >= StatusManager.Instance.PartJobCost.Value) && (StatusManager.Instance.PartJobCount.Value < GameInfo.MAX_PART_TIME_LEVEL) ? true : false;
        view.menuExtendButton.interactable = (StatusManager.Instance.Money.Value >= StatusManager.Instance.MenuCost.Value) && (StatusManager.Instance.MenuCount.Value < GameInfo.MAX_MENU_COUNT) ? true : false;
        view.seatExtendButton.interactable = (StatusManager.Instance.Money.Value >= StatusManager.Instance.SeatCost.Value) && (StatusManager.Instance.seatLevel < GameInfo.MAX_SEAT_LEVEL - 1) ? true : false;
    }
}