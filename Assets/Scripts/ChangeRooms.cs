using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRooms : MonoBehaviour
{
    private readonly Vector3 livingRoomPosition = new Vector3(0, 0, 0);
    private readonly Vector3 cantinaPosition = new Vector3(-50f, 0, 50f);
    private readonly Vector3 cubePosition = new Vector3(50f, 0, 50f);
    private readonly Vector3 mezzaninePosition = new Vector3(0, 0, 100f);

    public void Move(int room)
    {
        switch (room)
        {
            case 0:
                gameObject.transform.position = livingRoomPosition;
                break;
            case 1:
                gameObject.transform.position = cantinaPosition;
                break;
            case 2:
                gameObject.transform.position = cubePosition;
                break;
            case 3:
                gameObject.transform.position = mezzaninePosition;
                break;
            default:
                break;
        }
    }
}
