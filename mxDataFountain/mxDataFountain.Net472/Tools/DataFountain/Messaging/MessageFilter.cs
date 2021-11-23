using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePipe;

namespace mxProject.Tools.DataFountain.Messaging
{

    internal class MessageFilter<T> : MessageHandlerFilter<T>
    {
        public override void Handle(T message, Action<T> next)
        {
            System.Diagnostics.Debug.WriteLine("subscribing...");
            next(message);
            System.Diagnostics.Debug.WriteLine("subscribed.");
        }
    }

}
