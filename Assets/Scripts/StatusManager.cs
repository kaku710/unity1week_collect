using Communication;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class StatusManager : SingletonMonoBehaviour<StatusManager>
{   
    public ReactiveProperty<int> Money{
        get; private set;
    }
    public ReactiveProperty<int> PersonProductivity{
        get; private set;
    }
    public ReactiveProperty<float> SecondsProductivity{
        get; private set;
    }
    public ReactiveProperty<float> StayTime{
        get; private set;
    }
    public int snsLevel;
    public ReactiveProperty<int> SnsFollowers{
        get; private set;
    }
    public ReactiveProperty<int> SnsCost{
        get; private set;
    }

    private void Awake(){
        Money = new IntReactiveProperty();
        PersonProductivity = new IntReactiveProperty();
        SecondsProductivity = new FloatReactiveProperty();
        StayTime = new FloatReactiveProperty();
        snsLevel = 0;
        SnsFollowers = new IntReactiveProperty(CommandInfo.SNS_FOLLOWER_ARRAY[0]);
        SnsCost = new IntReactiveProperty(CommandInfo.SNS_COST_ARRAY[0]);
    }

    public void SetMoney(int money){
        this.Money.Value = money;
    }

    public void ChangeMoney(int money){
        this.Money.Value += money;
    }

    public void SetPersonProductivity(int person){
        this.PersonProductivity.Value = person;
    }

    public void ChangePersonProductivity(int person){
        this.PersonProductivity.Value += person;
    }

    public void SetSecondsProductivity(float seconds){
        this.SecondsProductivity.Value = seconds;
    }

    public void DownSecondsProductivity(float seconds){
        this.SecondsProductivity.Value -= seconds;
    }

    public void SetStayTime(float time){
        this.StayTime.Value = time;
    }

    public void SetSnsFollowes(int follower){
        this.SnsFollowers.Value = follower;
    }

    public void SetSnsCost(int cost){
        this.SnsCost.Value = cost;
    }
}
