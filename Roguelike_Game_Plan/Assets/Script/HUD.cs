﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    [SerializeField]
    private Slider m_Healthbar;
    [SerializeField]
    private Slider m_PowerBar;
    [SerializeField]
    private Text m_Score;
    private int m_MaxPower = 6;
    private int m_MaxHealth = 6;
    private void Start()
    {
        m_Healthbar.maxValue = m_MaxHealth;
        m_PowerBar.maxValue = m_MaxPower;
    }
    // Update is called once per frame
    public void Update () {
        try
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            m_Healthbar.value = player.GetComponent<PlayerController>().health;
            m_PowerBar.value = player.GetComponent<PlayerController>().GetPower;
            m_Score.text = player.GetComponent<PlayerController>().GetScore.ToString();
        }
        catch(Exception)
        {
            m_Healthbar.value = 0;
            m_PowerBar.value = 0;
        }
	}
}
