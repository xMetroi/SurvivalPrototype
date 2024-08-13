using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Hunger Properties")]
    [Tooltip("Actual value of hunger")]
    [SerializeField] private float hungerValue;
    [Tooltip("Max value of hunger")]
    [SerializeField] private float maxHungerValue;
    [Tooltip("How fast the hunger reduces his value ( in seconds )")]
    [SerializeField] private float hungerSpeed;

    [Tooltip("Actual value of hunger saturation")]
    [SerializeField] private float hungerSaturation;
    [Tooltip("How fast the hunger saturation reduces his value ( in seconds )")]
    [SerializeField] private float hungerSaturationSpeed;

    [Header("Thirst Properties")]
    [Tooltip("Actual value of thirst")]
    [SerializeField] private float thirstValue;
    [Tooltip("Max value of thirst")]
    [SerializeField] private float maxThirstValue;
    [Tooltip("How fast the thirst reduces his value ( in seconds )")]
    [SerializeField] private float thirstSpeed;

    [Tooltip("Actual thirst saturation value")]
    [SerializeField] private float thirstSaturation;
    [Tooltip("How fast the thirst saturation reduces his value")]
    [SerializeField] private float thirstSaturationSpeed;

    [Header("HUNGER TEST")]
    [SerializeField] private float foodValue;
    [SerializeField] private float foodSaturation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HungerManager();
        ThirstManager();
    }

    #region Survival stats

    #region Hunger

    private void HungerManager()
    {
        if (hungerSaturation > 0)
        {
            //Reduce hunger saturation
            hungerSaturation -= hungerSaturationSpeed * Time.deltaTime;
        }
        else
        {
            //Reduce hunger value
            hungerValue -= hungerSpeed * Time.deltaTime;
        }

        hungerValue = Mathf.Clamp(hungerValue, 0, maxHungerValue);
    }

    #endregion

    private void ThirstManager()
    {
        if (thirstSaturation > 0)
        {
            //Reduce thirst saturation
            thirstSaturation -= thirstSaturationSpeed * Time.deltaTime;
        }
        else
        {
            //Reduce thirst value
            thirstValue -= thirstValue * Time.deltaTime;
        }

        thirstValue = Mathf.Clamp(thirstValue, 0, maxThirstValue);
    }

    #endregion

    [ContextMenu("Test Food")]
    public void TestFood()
    {
        hungerValue += foodValue;
        hungerSaturation += foodSaturation;
    }
}
