using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class APIManager : MonoBehaviour
{ 
    public void APICall(string url)
    {
        StartCoroutine(GetRequest(url));
    }
    public IEnumerator GetRequest(string url)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(url);

        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log($"Error is {uwr.error}");
        }
        else
        {
            OnResponse(uwr.downloadHandler.text);
        }
    }

    public virtual void OnResponse(string response)
    {
        
    }
}
