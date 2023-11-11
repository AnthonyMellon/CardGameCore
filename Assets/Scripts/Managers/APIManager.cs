using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;
using System.Net.Http;

public class APIManager
{
    private static HttpClient JsonSource = new HttpClient()
    {
        BaseAddress = new System.Uri(GAConstants.ApiURL),
    };

    [MenuItem("CardGame/GetJSON")]
    private static async void DownloadJSON()
    {
        string result;

        //TODO: iterate through all pages somehow
        result = await JsonSource.GetStringAsync($"{JsonSource.BaseAddress}1");

        //TODO: create the cards too
        Debug.Log(result);
    }
}
