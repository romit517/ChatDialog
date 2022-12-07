using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LobbyPlayerPanel : MonoBehaviour
{
    [SerializeField] public TMPro.TMP_Text txtName;
    [SerializeField] public GameObject pnlColor;

    public void SetName(string newName) {
        txtName.text = newName;
    }

    public string GetName() {
        return txtName.text;
    }

    public void SetColor(Color c) {
        pnlColor.GetComponent<Image>().color = c;
    }
}
