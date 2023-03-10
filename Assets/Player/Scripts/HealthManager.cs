using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] float maxHitPoints = 100f;
    float hitPoints;

    public Slider healthSlider;

    void Start()
    {
        hitPoints = maxHitPoints;
    }

    void Hit(float rawDamage)
    {
        hitPoints -= rawDamage;
        SetHealthSlider();
        Debug.Log("OUCH: " + hitPoints.ToString());

        if(hitPoints <= 0)
        {
            
            onDeath();
        }
    }

    void SetHealthSlider()
    {
        if(healthSlider != null)
        {
            healthSlider.value = NormalisedHitPoints();
        }
    }

    float NormalisedHitPoints()
    {
        return hitPoints / maxHitPoints;
    }

    void onDeath()
    {
        Debug.Log("GAME OVER - YOU DIED");
        GameManager.Instance.GameOver();
    }
}
