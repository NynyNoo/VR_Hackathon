using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuController : MonoBehaviour
{
    private TeleportationProvider teleportationProvider;
    private SnapTurnProviderBase snapTurnProviderBase;
    private ContinuousMoveProviderBase contionusMoveProviderBase;
    private ContinuousTurnProviderBase continuousTurnProviderBase;
    private GameObject currentMenu;
    [SerializeField] private GameObject menuBox;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject movementMenu;
    [SerializeField] private GameObject turnMenu;
    [SerializeField] private GameObject snapInfo;
    [SerializeField] private GameObject continuousInfo;
    [SerializeField] private GameObject[] moveSpeedButtons;
    [SerializeField] private GameObject[] continuousTurnSpeedButtons;
    [SerializeField] private GameObject[] SnapTurnSpeedButtons;
    private void Start()
    {
        GameObject loco=GameObject.Find("Locomotion System");
        teleportationProvider=loco.GetComponent<TeleportationProvider>();
        snapTurnProviderBase= loco.GetComponent<SnapTurnProviderBase>();
        contionusMoveProviderBase = loco.GetComponent<ContinuousMoveProviderBase>();
        continuousTurnProviderBase = loco.GetComponent<ContinuousTurnProviderBase>();
        currentMenu = mainMenu;
    }
    public void SetMoveType(Slider movementsSlider)
    {
        if (movementsSlider.value >= 1)
        {
            teleportationProvider.enabled = true;
            contionusMoveProviderBase.enabled = false;
            ChangeButtonActivness(moveSpeedButtons);
        }
        else
        {
            teleportationProvider.enabled = false;
            contionusMoveProviderBase.enabled = true;
            ChangeButtonActivness(moveSpeedButtons);
        }
    }
    public void SetTurnType(Slider movementsSlider)
    {
        if(movementsSlider.value>=1)
        {
            snapTurnProviderBase.enabled = true;
            continuousTurnProviderBase.enabled = false;
            UpdateInfo();
            ReplaceButtons();
        }
        else
        {
            snapTurnProviderBase.enabled = false;
            continuousTurnProviderBase.enabled = true;
            UpdateInfo();
            ReplaceButtons();
        }
    }
    public void SetMovementSpeed(float value)
    {
        contionusMoveProviderBase.moveSpeed = value;
    }
    public void SetSnapTurnSpeed(float value)
    {
        snapTurnProviderBase.turnAmount = value;
    }
    public void SetContinuousTurnSpeed(float value)
    {
        continuousTurnProviderBase.turnSpeed = value;
    }
    public void ChangeButtonActivness(GameObject[] gameObjects)
    {
        foreach (var item in gameObjects)
        {
            item.SetActive(!item.active);
        }
    }
    public void ReplaceButtons()
    {
        foreach (var item in continuousTurnSpeedButtons)
        {
            item.SetActive(!item.active);
        }
        foreach (var item in SnapTurnSpeedButtons)
        {
            item.SetActive(!item.active);
        }
    }
    public void UpdateInfo()
    {
        snapInfo.SetActive(!snapInfo.active);
        continuousInfo.SetActive(!continuousInfo.active);
    }
    public void StartGame()
    {
        menuBox.SetActive(false);
    }
    public void OpenMenu(int id)
    {
        switch(id)
        {
            case 1:
                CloseMenu();
                currentMenu = mainMenu;
                mainMenu.SetActive(true);
                break;
            case 2:
                CloseMenu();
                currentMenu = movementMenu;
                movementMenu.SetActive(true);
                break;
            case 3:
                CloseMenu();
                currentMenu = turnMenu;
                turnMenu.SetActive(true);
                break;

        }
    }
    public void CloseMenu()
    {
        currentMenu.SetActive(false);
    }
}
