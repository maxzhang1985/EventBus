﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventBus
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent evt) where TEvent : IEvent;

        void Init();

    }
}
