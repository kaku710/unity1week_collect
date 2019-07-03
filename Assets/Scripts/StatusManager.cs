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

    private void Awake(){
        Money = new IntReactiveProperty();
        PersonProductivity = new IntReactiveProperty();
        SecondsProductivity = new FloatReactiveProperty();
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
}
