using System;
using System.Collections;
using System.Collections.Generic;
using Communication;
using UniRx;
using UnityEngine;

public class StatusManager : SingletonMonoBehaviour<StatusManager> {
    public ReactiveProperty<int> Money {
        get;
        private set;
    }
    public ReactiveProperty<int> PersonProductivity {
        get;
        private set;
    }
    public ReactiveProperty<float> SecondsProductivity {
        get;
        private set;
    }
    public ReactiveProperty<float> StayTime {
        get;
        private set;
    }
    [HideInInspector] public int snsLevel;
    public ReactiveProperty<int> SnsFollowers {
        get;
        private set;
    }
    public ReactiveProperty<int> SnsCost {
        get;
        private set;
    }
    public ReactiveProperty<int> PartJobCount {
        get;
        private set;
    }
    public ReactiveProperty<int> PartJobCost {
        get;
        private set;
    }
    public ReactiveProperty<int> MenuCount {
        get;
        private set;
    }
    public ReactiveProperty<int> MenuCost {
        get;
        private set;
    }
    [HideInInspector] public int minCharge;
    [HideInInspector] public int maxCharge;
    [HideInInspector] public int seatLevel;
    public ReactiveProperty<int> SeatCount {
        get;
        private set;
    }
    public ReactiveProperty<int> SeatCost {
        get;
        private set;
    }
    [HideInInspector] public int tapLevel;
    public ReactiveProperty<int> MinMoneyPerTap{
        get;
        private set;
    }
    public ReactiveProperty<int> MaxMoneyPerTap{
        get;
        private set;
    }
    public ReactiveProperty<int> TotalCustomerCount{
        get;
        private set;
    }

    private void Awake () {
        base.Awake ();
        SetDefaultValue();
    }

    private void SetDefaultValue(){
        Money = new IntReactiveProperty ();
        PersonProductivity = new IntReactiveProperty ();
        SecondsProductivity = new FloatReactiveProperty ();
        StayTime = new FloatReactiveProperty ();
        snsLevel = 0;
        SnsFollowers = new IntReactiveProperty (CommandInfo.SNS_FOLLOWER_ARRAY[0]);
        SnsCost = new IntReactiveProperty (CommandInfo.SNS_COST_ARRAY[0]);
        PartJobCount = new IntReactiveProperty (0);
        PartJobCost = new IntReactiveProperty (CommandInfo.PART_JOB_COST_ARRAY[0]);
        MenuCount = new IntReactiveProperty (1);
        MenuCost = new IntReactiveProperty (CommandInfo.MENU_COUNT_COST_ARRAY[0]);
        minCharge = CommandInfo.CHARGE_ARRAY[MenuCount.Value - 1];
        maxCharge = CommandInfo.CHARGE_ARRAY[MenuCount.Value];
        seatLevel = 0;
        SeatCount = new IntReactiveProperty (CommandInfo.SEAT_COUNT_ARRAY[0]);
        SeatCost = new IntReactiveProperty (CommandInfo.SEAT_COST_ARRAY[0]);
        tapLevel = 1;
        MinMoneyPerTap = new IntReactiveProperty(GameInfo.DEFAULT_MIN_MONEY_PER_TAP);
        MaxMoneyPerTap = new IntReactiveProperty(GameInfo.DEFAULT_MAX_MONEY_PER_TAP);
        TotalCustomerCount = new IntReactiveProperty(0);
    }

    public void SetMoney (int money) {
        this.Money.Value = money;
    }

    public void ChangeMoney (int money) {
        this.Money.Value += money;
    }

    public void SetPersonProductivity (int person) {
        this.PersonProductivity.Value = person;
    }

    public void ChangePersonProductivity (int person) {
        this.PersonProductivity.Value += person;
    }

    public void SetSecondsProductivity (float seconds) {
        this.SecondsProductivity.Value = seconds;
    }

    public void DownSecondsProductivity (float seconds) {
        this.SecondsProductivity.Value -= seconds;
    }

    public void SetStayTime (float time) {
        this.StayTime.Value = time;
    }

    public void DownStayTime (float time) {
        this.StayTime.Value -= time;
    }

    public void SetSnsFollowes (int follower) {
        this.SnsFollowers.Value = follower;
    }

    public void SetSnsCost (int cost) {
        this.SnsCost.Value = cost;
    }

    public void SetPartJobCost (int cost) {
        this.PartJobCost.Value = cost;
    }

    public void AddPartJobCount () {
        PartJobCount.Value++;
    }

    public void SetMenuCost (int cost) {
        this.MenuCost.Value = cost;
    }

    public void AddMenuCount () {
        MenuCount.Value++;
    }

    public void SetSeatCount(int count){
        this.SeatCount.Value = count;
    }

    public void SetSeatCost(int cost){
        this.SeatCost.Value = cost;
    }

    public void SetMoneyPerTap(int level){
        this.MinMoneyPerTap.Value = (int)(GameInfo.DEFAULT_MIN_MONEY_PER_TAP*(float)(Mathf.Pow(1.15f,level)));
        this.MaxMoneyPerTap.Value = (int)(GameInfo.DEFAULT_MAX_MONEY_PER_TAP*(float)(Mathf.Pow(1.15f,level)));
    }

    public void AddCustomerCount(){
        this.TotalCustomerCount.Value++;
    }
}