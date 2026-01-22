using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : BaseMenu
{
    private void OnEnable() { Player.UseWinMenu += ShowMenu; }
    private void OnDisable() { Player.UseWinMenu -= ShowMenu; }
    public override void Restart() { base.Restart(); HideMenu(); }
}
