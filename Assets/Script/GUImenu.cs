using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUImenu : MonoBehaviour
{
    [Header("Энергия")] public Slider BattaryBar;
    public void UpdateBattaryBar(int value)
    {
        BattaryBar.value = value;
    }
   
}
