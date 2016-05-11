using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.DesignPattern
{
    /// <summary>
    /// 单例模式
    /// </summary>
    public class Singleton
    {
        private volatile static Singleton singleton;
        private Singleton() { }
        private static object lockObject = new object();
        public static Singleton GetSingleton()
        {
            if(singleton==null)
            {
                lock(lockObject)
                {
                    if(singleton==null)
                    {
                        singleton = new Singleton();
                    }
                }
            }
            return singleton;
        }
    }
}
