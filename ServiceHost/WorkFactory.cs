using Common;
using ServiceHost.Works;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHost
{
    public class WorkFactory
    {
        private object _workObject;
        private Type _libType;
        public WorkFactory()
        {
            DirectoryInfo info = null;
            try
            {
                info = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                //查找符合命名规则的程序集              
                FileInfo[] files = info.GetFiles(ConfigHelper.LIB_RULE);           
                if (files.Count() > 0)
                {
                    //获取第一个符合条件的程序集
                    var libName = Path.GetFileNameWithoutExtension(files[0].Name);

                    //通过反射加载程序集
                    Assembly ass = Assembly.Load(libName);
                    //获取程序集中所有的类
                    Type[] types = ass.GetTypes();
                    
                    foreach (Type item in types)
                    {
                        //判断是否实现了IWork接口
                        if (typeof(IWork).IsAssignableFrom(item))
                        {
                            this._libType = item;
                            //通过无参构造函数创建实例，赋值给字段
                            this._workObject = Activator.CreateInstance(item);                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message + " " + ex.Source + "  " + ex.StackTrace);
            }
           

        }
        public void OnStart()
        {
            if (_workObject != null)
            {
                //获取方法的信息
                MethodInfo method = this._libType.GetMethod("OnStart");
                //调用方法的一些标志位，这里的含义是Public并且是实例方法，这也是默认的值
                BindingFlags flag = BindingFlags.Public | BindingFlags.Instance;
                //方法的参数
                object[] parameters = new object[] {  };
                //调用方法，不接受返回对象
               method.Invoke(this._workObject, flag, Type.DefaultBinder,null, null);
            }
        }

        public void Initialize()
        {   
            if (_workObject != null)
            {
                //获取方法的信息
                MethodInfo method = this._libType.GetMethod("Initialize");
                //调用方法的一些标志位，这里的含义是Public并且是实例方法，这也是默认的值
                BindingFlags flag = BindingFlags.Public | BindingFlags.Instance;
                //方法的参数
                object[] parameters = new object[] { };
                //调用方法，不接受返回对象
                method.Invoke(this._workObject, flag, Type.DefaultBinder, null, null);
            }
        }

        public void OnStop()
        {
            if (_workObject != null)
            {
                //获取方法的信息
                MethodInfo method = this._libType.GetMethod("OnStop");
                //调用方法的一些标志位，这里的含义是Public并且是实例方法，这也是默认的值
                BindingFlags flag = BindingFlags.Public | BindingFlags.Instance;
                //方法的参数
                object[] parameters = new object[] { };
                //调用方法，不接受返回对象
                method.Invoke(this._workObject, flag, Type.DefaultBinder, null, null);
            }
        }
    }
}
