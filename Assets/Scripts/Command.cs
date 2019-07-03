using System.Collections;
using System.Collections.Generic;
using Communication;
using UnityEngine;

public class Command : MonoBehaviour {
    public void OnSNSButtonClicked () {
        if (StatusManager.Instance.SecondsProductivity.Value > 1.002f) {
            float downRate = 0.7f;
            StatusManager.Instance.DownSecondsProductivity (downRate);
            if (StatusManager.Instance.SecondsProductivity.Value <= 1f) StatusManager.Instance.SetSecondsProductivity (1f);
        } else {
            StatusManager.Instance.ChangePersonProductivity (1);
        }
        StatusManager.Instance.snsLevel++;
        StatusManager.Instance.ChangeMoney (-(StatusManager.Instance.SnsCost.Value));
        StatusManager.Instance.SetSnsFollowes (CommandInfo.SNS_FOLLOWER_ARRAY[StatusManager.Instance.snsLevel]);
        StatusManager.Instance.SetSnsCost (CommandInfo.SNS_COST_ARRAY[StatusManager.Instance.snsLevel]);
    }

    public void OnWorkButtonClicked () {
        int money = Random.Range (20, 31); //あとで変える
        StatusManager.Instance.ChangeMoney(money);
    }
}