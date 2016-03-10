using System.Collections.Concurrent;

namespace Senri.AutoCode
{
    /// <summary>
    /// コマンド発行クラス
    /// C#　スクリプトのglobalsとして渡して、スクリプトからコマンドを発行するのに使う。
    /// </summary>
    class Commander
    {
        private ConcurrentQueue<Command> _queue;
        public Commander(ConcurrentQueue<Command> queue)
        {
            _queue = queue;
        }
        public void walk(double distance) => _queue.Enqueue(Command.Walk(distance));
        public void turn(double angle) => _queue.Enqueue(Command.Turn(angle));
        public void speed(double speedDotPersecond) => _queue.Enqueue(Command.Speed(speedDotPersecond));
    }
}
