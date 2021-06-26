using UnityEngine;

public static class ServiceLocator
{
    public static T LocateComponent<T>(UnityTag unityTag)
    {
        return GameObject.FindGameObjectWithTag(unityTag.ToString()).GetComponent<T>();
    }
}

public enum UnityTag
{
    EnemyManager,
    PlayerCharacter
}