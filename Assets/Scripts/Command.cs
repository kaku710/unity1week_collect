using System.Collections;
using System.Collections.Generic;
using Communication;
using UnityEngine;

public class Command : MonoBehaviour {
    [SerializeField] private RestaurantViewManager restaurantViewManager;
    public void OnSNSButtonClicked () {
        if (StatusManager.Instance.SecondsProductivity.Value > 0.402f) {
            float downRate = 0.3f;
            StatusManager.Instance.DownSecondsProductivity (downRate);
            if (StatusManager.Instance.SecondsProductivity.Value <= 0.401f) StatusManager.Instance.SetSecondsProductivity (0.4f);
        } else {
            StatusManager.Instance.ChangePersonProductivity (1);
        }
        if (StatusManager.Instance.snsLevel < GameInfo.MAX_SNS_LEVEL) {
            StatusManager.Instance.snsLevel++;
            StatusManager.Instance.ChangeMoney (-(StatusManager.Instance.SnsCost.Value));
            StatusManager.Instance.SetSnsFollowes (CommandInfo.SNS_FOLLOWER_ARRAY[StatusManager.Instance.snsLevel]);
            StatusManager.Instance.SetSnsCost (CommandInfo.SNS_COST_ARRAY[StatusManager.Instance.snsLevel]);
            StatusManager.Instance.tapLevel++;
            StatusManager.Instance.SetMoneyPerTap(StatusManager.Instance.tapLevel);
        }
    }

    public void OnWorkButtonClicked () {
        int money = Random.Range (StatusManager.Instance.MinMoneyPerTap.Value, StatusManager.Instance.MaxMoneyPerTap.Value + 1); //あとで変える
        StatusManager.Instance.ChangeMoney (money);
    }

    public void OnEmployButtonClicked () {
        if (StatusManager.Instance.PartJobCount.Value < GameInfo.MAX_PART_TIME_LEVEL) {
            StatusManager.Instance.AddPartJobCount ();
            StatusManager.Instance.ChangeMoney (-(StatusManager.Instance.PartJobCost.Value));
            float downTime = 0.5f; 
            StatusManager.Instance.DownStayTime (downTime);
            StatusManager.Instance.SetPartJobCost (CommandInfo.PART_JOB_COST_ARRAY[StatusManager.Instance.PartJobCount.Value]);
            StatusManager.Instance.tapLevel++;
            StatusManager.Instance.SetMoneyPerTap(StatusManager.Instance.tapLevel);
        }
    }

    public void OnMenuExtendButtonClicked () {
        if (StatusManager.Instance.MenuCount.Value < GameInfo.MAX_MENU_COUNT) {
            StatusManager.Instance.ChangeMoney (-(StatusManager.Instance.MenuCost.Value));
            StatusManager.Instance.AddMenuCount ();
            //客の単価をあげる処理
            StatusManager.Instance.minCharge = CommandInfo.CHARGE_ARRAY[StatusManager.Instance.MenuCount.Value - 1];
            StatusManager.Instance.maxCharge = CommandInfo.CHARGE_ARRAY[StatusManager.Instance.MenuCount.Value];
            StatusManager.Instance.SetMenuCost (CommandInfo.MENU_COUNT_COST_ARRAY[StatusManager.Instance.MenuCount.Value - 1]);
            StatusManager.Instance.tapLevel++;
            StatusManager.Instance.SetMoneyPerTap(StatusManager.Instance.tapLevel);
        }
    }

    public void OnSeatExtendButtonClicked () {
        if (StatusManager.Instance.seatLevel < GameInfo.MAX_SEAT_LEVEL) {
            StatusManager.Instance.ChangeMoney (-(StatusManager.Instance.SeatCost.Value));
            StatusManager.Instance.seatLevel++;
            StatusManager.Instance.SetSeatCount (CommandInfo.SEAT_COUNT_ARRAY[StatusManager.Instance.seatLevel]);
            StatusManager.Instance.SetSeatCost (CommandInfo.SEAT_COST_ARRAY[StatusManager.Instance.seatLevel]);
            StatusManager.Instance.tapLevel++;
            StatusManager.Instance.SetMoneyPerTap(StatusManager.Instance.tapLevel);
            restaurantViewManager.ExtendRestaurant();
        }
    }
}