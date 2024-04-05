using Cinemachine;
using UnityEngine;

public class CinemachineScript : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] CinemachineFramingTransposer framing;
    bool inverted = false;

    void Start()
    {
        framing = cam.GetCinemachineComponent<CinemachineFramingTransposer>();
    }
    
    void Update()
    {/*
        if (Input.GetKeyDown(KeyCode.V)){   
            if (!inverted) {
                framing.m_TrackedObjectOffset = new Vector3(5.5f, -2.5f, 0f);
                inverted = true;
            }
            else {
                framing.m_TrackedObjectOffset = new Vector3(5.5f, 2.5f, 0f);
                inverted = false;
            }
        }*/
    }

}
