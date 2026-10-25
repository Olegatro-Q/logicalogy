using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class debug : MonoBehaviour
{
    [Header("Variables")]
    public bool debugModeOn;
    private bool LIST_OBJECTS_isOn;

    // public List<GameObject> ListDebugObjects; // список дебаг объектов для дальнейших манипуляций с ними (для быстрого выкл и вкл)

    [Header("UI Objects")]
    public Toggle toggle_DEBUG_MODE; // галочка | вкл./выкл. дебаг мод
    public TextMeshProUGUI text_State_LIST_OBJECTS;

    public Button ButtonOPEN_LIST_OBJECTS; // кнопка | открыть список объектов для дебага
    public GameObject LIST_OBJECTS; // список объектов для дебага


    void Start()
    {

    }


    void Update()
    {
        debugModeOn = toggle_DEBUG_MODE.isOn;
        text_State_LIST_OBJECTS.text = LIST_OBJECTS.activeInHierarchy.ToString();

        /* if(debugModeOn == true)
        {
            foreach(GameObject obj in ListDebugObjects)
            {
                obj.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject obj in ListDebugObjects)
            {
                obj.SetActive(false);
            }
        } */

        if (debugModeOn == true)
        {
            ButtonOPEN_LIST_OBJECTS.gameObject.SetActive(true);
        }
        else
        {
            ButtonOPEN_LIST_OBJECTS.gameObject.SetActive(false);
        }

        if (LIST_OBJECTS.activeInHierarchy == true)
        {
            toggle_DEBUG_MODE.interactable = false;
            text_State_LIST_OBJECTS.color = Color.green;
        }
        else
        {
            toggle_DEBUG_MODE.interactable = true;
            text_State_LIST_OBJECTS.color = Color.red;
        }
    }

    public void open_list_objects()
    {
        LIST_OBJECTS.SetActive(true);
    }

    public void close_list_objects()
    {
        LIST_OBJECTS.SetActive(false);
        ButtonOPEN_LIST_OBJECTS.gameObject.SetActive(true);
    }
}
