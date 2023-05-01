using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    [SerializeField]
    private GameObject _melon;
    public void DestroyMelon()
    {
        _melon.SetActive(false);
    }
}
