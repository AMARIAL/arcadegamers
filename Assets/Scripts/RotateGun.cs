using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    [SerializeField] private Transform aim;

    private void Update()
    {
        Vector2 direction = aim.position - transform.position;
        var atan2 = Mathf.Rad2Deg * (Math.Atan2(direction.y, direction.x));

        transform.rotation = Quaternion.Euler(0, 0, Convert.ToSingle(atan2) - 90f);
    }
}
