using Common;
using ServiceHost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
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
        private Timer timer1 = null;
        protected override void OnStart(string[] args)
        {
            try
            {
                this._workFactory.Initialize();
                this._workFactory.OnStart();
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.Message + " " + ex.Source + "  " + ex.StackTrace);
            }
          
        }

      
    

        protected override void OnStop()
        {
            try
            {
                this._workFactory.OnStop();
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.Message + " " + ex.Source + "  " + ex.StackTrace);
            }
            
        }
    }
}
