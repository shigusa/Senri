using System;
using System.Linq;

namespace Senri.Models
{
    /// <summary>
    /// タイマーの実装部分
    /// 0.2秒毎に実行される
    /// </summary>
    class Timer
    {
        private TimeSpan time;
        //5回の内一度でも実行されているかの真偽値
        private bool ors;
    }
}
