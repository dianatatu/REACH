using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using REACH.Client.Core;

namespace REACH.Client.Base
{
    public abstract class ControllerBase<T> : IController
            where T : IModel
    {
        protected T model;
        public delegate void ExternalEventHandler(T model);
    }
}
