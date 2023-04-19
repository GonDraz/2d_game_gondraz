using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocalizationManager : MonoBehaviour
{
private bool active = false;

    public void ChangeLocale(int id)
    {
        if (active) { return; }
        StartCoroutine(SetLocale(id)); 
    }

    private IEnumerator SetLocale(int id)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[id];
        active = false;
    }
}
