using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffSpawner : MonoBehaviour {
    [SerializeField] private Staff staff;
    private Vector3 spawnPos;
    private Quaternion spawnAngle;

    public void SpawnStaff () {
        if (StatusManager.Instance.PartJobCount.Value % 2 == 1) {
            spawnPos = new Vector3 (-2.7f, 0, -1.35f  + 1.15f * (StatusManager.Instance.PartJobCount.Value / 2));
            spawnAngle = Quaternion.Euler (0, 90, 0);
        } else {
            spawnPos = new Vector3 (-3.25f, 0, -0.9f + 1.15f * ((StatusManager.Instance.PartJobCount.Value / 2) - 1));
            spawnAngle = Quaternion.Euler (0, -90, 0);
        }
        var obj = Instantiate (staff, spawnPos, spawnAngle);
        obj.ID = StatusManager.Instance.PartJobCount.Value;
    }
}