using Common;
using ServiceHost;
using ServiceHost.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService_Template
{
    public partial class Service1 : ServiceBase
    {
        private WorkFactory _workFactory;
        public Service1()
        {
            InitializeComponent();
            _workFactory = new WorkFactory();
        }
        private System.Timers.Timer aTimer = new System.Timers.Timer();
        protected override void OnStart(string[] args)
        {
            try
            {
           this._workFactory.Initialize();
            ServiceModel model = XmlReaderHelper.ReadXml(AppDomain.CurrentDomain.BaseDirectory+@"Config\Service.xml");         
            aTimer.Elapsed += timer_Elapsed; 
      
            string[] checkTime = model.ServiceDefinition.Service.LongCheckForWorkInterVal.Split(':');
            aTimer.Interval = Convert.ToInt32(checkTime[0]) * 3600000 + Convert.ToInt32(checkTime[1]) * 60000 + Convert.ToInt32(checkTime[2])*1000;

            aTimer.Enabled = true;
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.Message + " " + ex.Source + "  " + ex.StackTrace);
            }
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            aTimer.Stop();
            try
            {
            this._workFactory.OnStart();

            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.Message + " " + ex.Source + "  " + ex.StackTrace);
            }
            aTimer.Start();
        }

      
    

        protected override void OnStop()
        {
            try
            {
                this._workFactory.OnStop();
                aTimer.Stop();
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.Message + " " + ex.Source + "  " + ex.StackTrace);
            }
            
        }
    }
}
