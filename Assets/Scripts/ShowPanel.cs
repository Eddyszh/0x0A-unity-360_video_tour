using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPanel : MonoBehaviour
{
    [SerializeField] private Canvas panel;

    public void GetPanel()
    {
        panel.enabled ^= true;
    }
}
