using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{
    public static ServiceLocator Current { get; private set; }
    private readonly Dictionary<string, IService> _services = new();

    private ServiceLocator() { }
  


    public static void Initialize()
    {
        Current = new();
    }


    public bool CheckService<T>() where T: IService
    {
        if (_services.ContainsKey(typeof(T).Name)) return true;
        return false;
    }

    public void RegisterService<T>(T service) where T:IService
    {
        if(CheckService<T>())
        {
            Debug.Log(typeof(T).Name + " Already registerd");
            return;
        }
        else
        {
            _services.Add(typeof(T).Name, service);
            service.RegisterHandler();
            
        }
       
    }

    public T GetService<T>() where T: IService 
    {
        if(!CheckService<T>())
        {
            throw new Exception(typeof(T).Name + " not registred");
        }
        return (T)_services[typeof(T).Name];
    }
        

}
