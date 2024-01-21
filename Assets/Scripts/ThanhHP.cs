using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThanhHP : MonoBehaviour
{
    public UnityEngine.UI.Image thanhHP;

    public void trangThaiThanhSinhMenh(float hpNow, float hpMax)
    {
        thanhHP.fillAmount = hpNow / hpMax;
    }

}
