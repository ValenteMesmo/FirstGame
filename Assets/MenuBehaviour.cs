using UnityEngine;
using System;
using GooglePlayGames;

public class MenuBehaviour : MonoBehaviour
{
    private LoginOnTouch btnLogin;
    private LogoffOnTouch btnLogoff;

    protected void Awake()
    {
        PlayGamesPlatform.Activate();
        
    }

    void Start()
    {
        btnLogin = GetComponentInChildren<LoginOnTouch>();
        if (btnLogin == null)
            throw new Exception("'btnLogin' is required");
        btnLogoff = GetComponentInChildren<LogoffOnTouch>();
        if (btnLogoff == null)
            throw new Exception("'btnLogoff' is required");

        btnLogoff.OnClick += btnLogoff_OnClick;
        btnLogin.OnClick += btnLogin_OnClick;

        if (SavedInfo.GetIsAuthenticated())
            btnLogin_OnClick(this, null);
    }

    void btnLogin_OnClick(object sender, EventArgs e)
    {
        if (Social.localUser.authenticated == false)
        {
            Social.localUser.Authenticate(success =>
            {
                if (success)
                {
                    SavedInfo.SetHighScore(0);
                    SavedInfo.SetIsAuthenticated(true);
                }
            });
        }
    }

    void btnLogoff_OnClick(object sender, EventArgs e)
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
        SavedInfo.SetIsAuthenticated(false);
    }

    void Update()
    {
        if (Social.localUser.authenticated)
        {
            btnLogin.gameObject.SetActive(false);
            btnLogoff.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            btnLogin.gameObject.SetActive(true);
            btnLogoff.transform.parent.gameObject.SetActive(false);
        }
    }
}
