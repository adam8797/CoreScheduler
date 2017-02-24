using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreScheduler.Api;

namespace Example.Jobs.JOB_NAME
{
    public class JOB_NAME : MarshalByRefObject, IRunnable
    {
        public void Main(IContext ctx)
        {
            ctx.Events.Add(EventLevel.Info, "Isn't this awesome?!");
        }
    }
}
