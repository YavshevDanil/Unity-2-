using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Flashlight : Baseobject
{

    [SerializeField] private Light flashlightLight;
    [Header("Максимум енергия")]
    public int battary = 40;
    public int usingbattary = 1;
    public float currTime = 0;
    public float currReloadtime = 0;
    public GUImenu gUImenu;
    [Header("Текущее енергии")]
    public int curbattary;
    [Header("Скорость восполнения энергии")]
    public float battaryRegenerateTime = 1f;
    [Header("Задержка перед восстановлением ресурсов")]
    public float waitingRegenerationTime;
    private float curBattaryTime = 0f;
    float curWaitingTime = 0f;
    private KeyCode control = KeyCode.F;

   protected override void Awake()
    {
        base.Awake();
        flashlightLight = GetComponentInChildren<Light>();

    }

    private void ActiveFlashLight(bool val)
    {
        flashlightLight.enabled = val;
    }


   void Start()
    {
        gUImenu = FindObjectOfType<GUImenu>();
        gUImenu.UpdateBattaryBar(battary);

        curWaitingTime = waitingRegenerationTime;
        curbattary = battary;
    }
   
    private void ResourceRegenerate()
    {
        curBattaryTime += Time.deltaTime;

        if (curBattaryTime >= battaryRegenerateTime && curbattary < battary)
        {
            curBattaryTime = 0;
            AddBattary(1);
        }
    }

    public void AddBattary(int battaryToAdd)
    {
        curbattary += battaryToAdd;
       

        if ((float)curbattary / (float)battary > 0.3f)
        {
            
        }
    }
    void Update()
    {
        
        if (Input.GetKeyDown(control)  && !flashlightLight.enabled)
        {
            ActiveFlashLight(true);
        }
        else if (Input.GetKeyDown(control) && flashlightLight.enabled)
        {
            ActiveFlashLight(false);
        }

        if (flashlightLight.enabled)
        {

            curbattary -= usingbattary;
            
            if (curbattary <= 0)
            {
                ActiveFlashLight(false);
            }

           
        }
        if (curWaitingTime >= waitingRegenerationTime)
        {
            ResourceRegenerate();
        }
        else
        {
            curWaitingTime += Time.deltaTime;
        }
    }
}
