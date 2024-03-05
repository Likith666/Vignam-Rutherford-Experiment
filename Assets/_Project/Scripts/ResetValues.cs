using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetValues : MonoBehaviour
{
    [SerializeField]
    Toggle rayButton;
    [SerializeField]
    Toggle elementAu;
    [SerializeField]
    Toggle elementCu;
    [SerializeField]
    Toggle elementAl;
    [SerializeField]
    Toggle alphaTraces;

    [SerializeField]
    Slider protonSlider;
    [SerializeField]
    Slider neutronSlider;
    [SerializeField]
    Slider alphaEnergy;

    bool toggleEnable = false;

    public void ValueReset()
    {
        rayButton.isOn = toggleEnable;
        elementAu.isOn = toggleEnable;
        elementCu.isOn = toggleEnable;
        elementAl.isOn = toggleEnable;
        alphaTraces.isOn = toggleEnable;

        protonSlider.value = 10f;
        neutronSlider.value = 10f;
        alphaEnergy.value = 1f;
    }
}
