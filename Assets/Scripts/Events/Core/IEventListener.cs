using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E404.Core
{
    public interface IEventListener<in T>
    {
        void OnEventRaised(T value);
    }
}
//EOF.