using System;
using UnityEngine;

public static class ServiceLocator
{
    public static T LocateComponent<T>(UnityTag unityTag)
    {
        var component = GameObject.FindGameObjectWithTag(unityTag.Tag()).GetComponent<T>();
        if(component == null) throw new NullReferenceException($"Game Object with tag: {unityTag} does not have a component of type: {typeof(T)}");
        return component;
    }
}

public enum UnityTag
{
    EnemyManager,
    PlayerCharacter
}

public static class UnityTagExtension
{
    public static string Tag(this UnityTag tag) => tag.ToString();
}