using System;
using System.Collections.Generic;
using UnityEngine;

public class SceneServiceLocator 
{
    


    private readonly Dictionary<string, IService> _services = new Dictionary<string, IService>();

    

  


    public T Get<T>() where T : IService
    {
        string key = typeof(T).Name;
        if (!_services.ContainsKey(key))
        {
            Debug.LogError($"{key} not registered with {GetType().Name}");
            throw new InvalidOperationException();
        }

        return (T)_services[key];
    }


    public void Register<T>(T service) where T : IService
    {
        string key = typeof(T).Name;
        if (_services.ContainsKey(key))
        {
            Debug.LogError(
                $"Service of type {key}  is already registered with the {GetType().Name}.");
            return;
        }

        _services.Add(key, service);

        Debug.Log($"Servise of type - {key} - registred. ");
    }


    public void Unregister<T>() where T : IService
    {
        string key = typeof(T).Name;
        if (!_services.ContainsKey(key))
        {
            Debug.LogError(
                $"Can't  unregister service of type {key} which is not registered with the {GetType().Name}.");
            return;
        }

        _services.Remove(key);
        Debug.Log($"Servise of type - {key} - unregistred. ");
    }
}

