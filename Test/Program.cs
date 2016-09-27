using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
           
          



       System.Timers.Timer aTimer = new System.Timers.Timer();
 
      
       // TODO: 在此处添加代码以启动服务。
            aTimer.Elapsed += new ElapsedEventHandler(OnTimer);
            aTimer.Interval = 5000 ; //每小时
            aTimer.Enabled = true;
            aTimer.Start();
                
 
     
      
  
         //   int x=0;
         //   int y=0;
       
         //   System.Timers.Timer timer = new System.Timers.Timer();
         //   timer.Elapsed += timer_Elapsed;
         //  // timer.Interval = 10;
         //   timer.Start();
         //// timer.Enabled = true;
         

            Console.Read();
        }
        public static void OnTimer(object state, ElapsedEventArgs e)
        {
            System.Timers.Timer aTimer = (System.Timers.Timer)state;
            aTimer.Stop();

                Console.WriteLine("xxx");
                Thread.Sleep(3000);

            aTimer.Start();
            Console.WriteLine("11");
           
        }
       static void Work(object sender)
        {
            int i = 0;
            int j = 0;
            ThreadPool.GetAvailableThreads(out i, out j);
            Console.WriteLine(i.ToString() + "   " + j.ToString()); //默认都是1000
            Thread.Sleep(10000);
        }
        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
        Console.WriteLine(DateTime.Now);
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            int i=0;
            int j=0;
        //获取空闲线程，由于现在没有使用异步线程，所以为空
        ThreadPool.GetAvailableThreads(out i, out j);
        Console.WriteLine(i.ToString() + "   " + j.ToString()); //默认都是1000
        Thread.Sleep(10000);
        
        }


    }

    public class ServiceModel
    {
        public ServiceModel()
        {
            ServiceDefinition = new ServiceDefinition();
        }

        public ServiceDefinition ServiceDefinition { get; set; }



    }
    public class Service
    {
        public string LongCheckForWorkInterVal { get; set; }
    }
    public class ServiceDefinition
    {
        public ServiceDefinition()
        {
            Service = new Service();
        }
        private string _serviceName;
        public string ServiceName
        {
            get { return _serviceName; }
            set { _serviceName = value; }
        }
        private string _serviceDescription;

        public string ServiceDescription
        {
            get { return _serviceDescription; }
            set { _serviceDescription = value; }
        }
        public Service Service { get; set; }

    }
}
