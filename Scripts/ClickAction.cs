using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ClickAction : MonoBehaviour
{


    public void OnMouseUp()
    {
        Debug.Log("UP");
        GameManager.instance.ClickedObjMethod(this.gameObject);


    }


}
