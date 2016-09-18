using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceHost;
using ServiceHost.Works;

namespace MyWorkLibrary
{
    public class Work : IWork
    {
       
        public void Initialize()
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("d:\\logs\\windowsServicelog.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "MyWorkLibrary 初始化了.");
                sw.Flush();
                sw.Close();
            }
            
        }

        public void OnStart()
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("d:\\logs\\windowsServicelog.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "MyWorkLibrary工作了.");
                sw.Flush();
                sw.Close();
            }
        }

        public void OnStop()
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("d:\\logs\\windowsServicelog.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "MyWorkLibrary 停止了.");
                sw.Flush();
                sw.Close();
            }
            
        }
    }
}
