using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCenter
{
    //事件存储集合 Dictionary<事件钥匙，委托类型>
    private static Dictionary<EventDefine, Delegate> m_EventTable = new Dictionary<EventDefine, Delegate>();

    //添加事件时安全校验，对事件类型进行判断
    private static void OnListenerAdding(EventDefine EventDefine, Delegate callBack)
    {
        if (!m_EventTable.ContainsKey(EventDefine))
        {
            m_EventTable.Add(EventDefine, null);
        }
        Delegate d = m_EventTable[EventDefine];
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception(string.Format("尝试为事件{0}添加不同类型的委托，当前事件所对应的委托是{1}，要添加的委托类型为{2}", EventDefine, d.GetType(), callBack.GetType()));
        }
    }
    private static void OnListenerRemoving(EventDefine EventDefine, Delegate callBack)
    {
        if (m_EventTable.ContainsKey(EventDefine))
        {
            Delegate d = m_EventTable[EventDefine];
            if (d == null)
            {
                throw new Exception(string.Format("移除监听错误：事件{0}没有对应的委托", EventDefine));
            }
            else if (d.GetType() != callBack.GetType())
            {
                throw new Exception(string.Format("移除监听错误：尝试为事件{0}移除不同类型的委托，当前委托类型为{1}，要移除的委托类型为{2}", EventDefine, d.GetType(), callBack.GetType()));
            }
        }
        else
        {
            throw new Exception(string.Format("移除监听错误：没有事件码{0}", EventDefine));
        }
    }
    //移除事件对应的委托后，删除对应的事件
    private static void OnListenerRemoved(EventDefine EventDefine)
    {
        if (m_EventTable[EventDefine] == null)
        {
            m_EventTable.Remove(EventDefine);
        }
    }
    //no parameters
    public static void AddListener(EventDefine EventDefine, CallBack callBack)
    {
        OnListenerAdding(EventDefine, callBack);
        m_EventTable[EventDefine] = (CallBack)m_EventTable[EventDefine] + callBack;
    }
    //Single parameters
    public static void AddListener<T>(EventDefine EventDefine, CallBack<T> callBack)
    {
        OnListenerAdding(EventDefine, callBack);
        m_EventTable[EventDefine] = (CallBack<T>)m_EventTable[EventDefine] + callBack;
    }
    //two parameters
    public static void AddListener<T, X>(EventDefine EventDefine, CallBack<T, X> callBack)
    {
        OnListenerAdding(EventDefine, callBack);
        m_EventTable[EventDefine] = (CallBack<T, X>)m_EventTable[EventDefine] + callBack;
    }
    //three parameters
    public static void AddListener<T, X, Y>(EventDefine EventDefine, CallBack<T, X, Y> callBack)
    {
        OnListenerAdding(EventDefine, callBack);
        m_EventTable[EventDefine] = (CallBack<T, X, Y>)m_EventTable[EventDefine] + callBack;
    }
    //four parameters
    public static void AddListener<T, X, Y, Z>(EventDefine EventDefine, CallBack<T, X, Y, Z> callBack)
    {
        OnListenerAdding(EventDefine, callBack);
        m_EventTable[EventDefine] = (CallBack<T, X, Y, Z>)m_EventTable[EventDefine] + callBack;
    }
    //five parameters
    public static void AddListener<T, X, Y, Z, W>(EventDefine EventDefine, CallBack<T, X, Y, Z, W> callBack)
    {
        OnListenerAdding(EventDefine, callBack);
        m_EventTable[EventDefine] = (CallBack<T, X, Y, Z, W>)m_EventTable[EventDefine] + callBack;
    }

    //no parameters
    public static void RemoveListener(EventDefine EventDefine, CallBack callBack)
    {
        OnListenerRemoving(EventDefine, callBack);
        m_EventTable[EventDefine] = (CallBack)m_EventTable[EventDefine] - callBack;
        OnListenerRemoved(EventDefine);
    }
    //single parameters
    public static void RemoveListener<T>(EventDefine EventDefine, CallBack<T> callBack)
    {
        OnListenerRemoving(EventDefine, callBack);
        m_EventTable[EventDefine] = (CallBack<T>)m_EventTable[EventDefine] - callBack;
        OnListenerRemoved(EventDefine);
    }
    //two parameters
    public static void RemoveListener<T, X>(EventDefine EventDefine, CallBack<T, X> callBack)
    {
        OnListenerRemoving(EventDefine, callBack);
        m_EventTable[EventDefine] = (CallBack<T, X>)m_EventTable[EventDefine] - callBack;
        OnListenerRemoved(EventDefine);
    }
    //three parameters
    public static void RemoveListener<T, X, Y>(EventDefine EventDefine, CallBack<T, X, Y> callBack)
    {
        OnListenerRemoving(EventDefine, callBack);
        m_EventTable[EventDefine] = (CallBack<T, X, Y>)m_EventTable[EventDefine] - callBack;
        OnListenerRemoved(EventDefine);
    }
    //four parameters
    public static void RemoveListener<T, X, Y, Z>(EventDefine EventDefine, CallBack<T, X, Y, Z> callBack)
    {
        OnListenerRemoving(EventDefine, callBack);
        m_EventTable[EventDefine] = (CallBack<T, X, Y, Z>)m_EventTable[EventDefine] - callBack;
        OnListenerRemoved(EventDefine);
    }
    //five parameters
    public static void RemoveListener<T, X, Y, Z, W>(EventDefine EventDefine, CallBack<T, X, Y, Z, W> callBack)
    {
        OnListenerRemoving(EventDefine, callBack);
        m_EventTable[EventDefine] = (CallBack<T, X, Y, Z, W>)m_EventTable[EventDefine] - callBack;
        OnListenerRemoved(EventDefine);
    }


    //no parameters
    public static void Broadcast(EventDefine EventDefine)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(EventDefine, out d))
        {
            CallBack callBack = d as CallBack;
            if (callBack != null)
            {
                callBack();
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应委托具有不同的类型", EventDefine));
            }
        }
    }
    //single parameters
    public static void Broadcast<T>(EventDefine EventDefine, T arg)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(EventDefine, out d))
        {
            CallBack<T> callBack = d as CallBack<T>;
            if (callBack != null)
            {
                callBack(arg);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应委托具有不同的类型", EventDefine));
            }
        }
    }
    //two parameters
    public static void Broadcast<T, X>(EventDefine EventDefine, T arg1, X arg2)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(EventDefine, out d))
        {
            CallBack<T, X> callBack = d as CallBack<T, X>;
            if (callBack != null)
            {
                callBack(arg1, arg2);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应委托具有不同的类型", EventDefine));
            }
        }
    }
    //three parameters
    public static void Broadcast<T, X, Y>(EventDefine EventDefine, T arg1, X arg2, Y arg3)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(EventDefine, out d))
        {
            CallBack<T, X, Y> callBack = d as CallBack<T, X, Y>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应委托具有不同的类型", EventDefine));
            }
        }
    }
    //four parameters
    public static void Broadcast<T, X, Y, Z>(EventDefine EventDefine, T arg1, X arg2, Y arg3, Z arg4)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(EventDefine, out d))
        {
            CallBack<T, X, Y, Z> callBack = d as CallBack<T, X, Y, Z>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3, arg4);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应委托具有不同的类型", EventDefine));
            }
        }
    }
    //five parameters
    public static void Broadcast<T, X, Y, Z, W>(EventDefine EventDefine, T arg1, X arg2, Y arg3, Z arg4, W arg5)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(EventDefine, out d))
        {
            CallBack<T, X, Y, Z, W> callBack = d as CallBack<T, X, Y, Z, W>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3, arg4, arg5);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应委托具有不同的类型", EventDefine));
            }
        }
    }
}
