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

    public static async void DownloadJSON(int page)
    {
        string result;

        //TODO: iterate through all pages somehow
        result = await JsonSource.GetStringAsync($"{JsonSource.BaseAddress}{page}");

        //TODO: create the cards too
        Debug.Log(result);
    }
}
