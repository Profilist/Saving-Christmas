using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporter : MonoBehaviour
{
    [SerializeField] public string destinationName;

    public void TeleportSceneDestination()
    {
        SceneManager.LoadScene(destinationName);
    }
    //public Transform GetSceneDestination()
    //{
    //    if (destination != null)
    //    {
    //        return destination;
    //    }
    //    return null;
    //}
}
