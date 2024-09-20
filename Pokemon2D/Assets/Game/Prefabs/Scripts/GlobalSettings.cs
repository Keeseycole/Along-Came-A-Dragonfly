using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    [SerializeField] Color highlightedColor;

    public Color HighlighedColor => highlightedColor;

    public static GlobalSettings i { get; private set; }
    public Color HighlightedColor { get; internal set; }

    private void Awake()
    {
        i = GetComponent<GlobalSettings>();
    }

    public static bool HasParameter(string paramName, Animator animator)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName)
                return true;
        }
        return false;
    }

}
