using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;


public class Main : NetworkBehaviour {

    public Button btnHost;
    public Button btnClient;
    public TMPro.TMP_Text txtStatus;

    public void Start()
    {
        btnHost.onClick.AddListener(OnHostClicked);
        btnClient.onClick.AddListener(OnClientClicked);
    }

    private void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.SceneManager.LoadScene("Lobby", UnityEngine.SceneManagement.LoadSceneMode.Single);

    }

    private void OnHostClicked()
    {
        btnClient.gameObject.SetActive(false);
        btnHost.gameObject.SetActive(false);
        txtStatus.text = "Starting Host";
        StartHost();
    }

    private void OnClientClicked()
    {
        btnClient.gameObject.SetActive(false);
        btnHost.gameObject.SetActive(false);
        txtStatus.text = "Waiting On Host";
        NetworkManager.Singleton.StartClient();

    }
}
