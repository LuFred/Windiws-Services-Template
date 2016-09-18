using ServiceHost.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHost.Works
{
  public  interface IWork
    {

      void OnStart();
      void Initialize();

      void OnStop();
    }
}
