using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class DemoHelper
    {
    }
    #region=======C#中实现多继承=========
    //C#中实现多继承
    /// <summary>
    /// 定义一个飞的接口
    /// </summary>
    public interface IFly
    {

    }
    /// <summary>
    /// 定义一个拓展类来为接口添加方法，继承该接口的类就能拥有这个方法，如何：IFly
    /// </summary>
    public static class ExtendClass
    {
        public static void Fly<T>(this T childrenClass)where T:IFly
        {
            Console.Write("我会飞了");
        }
    }
    /// <summary>
    /// 老虎类继承IFly接口，并且继承的Fly方法
    /// </summary>
    public class Tiger:IFly
    {
        public void TigerFly()
        {
            this.Fly();
        }

    }
    #endregion===============
}
