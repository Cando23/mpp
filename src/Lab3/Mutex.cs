using System.Threading;

namespace Lab3
{
    public class Mutex
    {
        /* int InterLocked.CompareExchange(ref int location1, int value, int comparand)
         * Метод принимает три значения: первое передается по ссылке и это то значение,
         * которое будет изменено на второе,
         * если в момент сравнения location1 совпадает с comparand.
         * то оригинальное значение location1 - результат функции.
         */
        private int _locationId = -1;

        public void Lock()
        {
            var id = Thread.CurrentThread.ManagedThreadId;
            while (Interlocked.CompareExchange(ref _locationId, id, -1) != -1)
            {
                Thread.Sleep(100);
            }
        }

        public void Unlock()
        {
            var id = Thread.CurrentThread.ManagedThreadId;
            Interlocked.CompareExchange(ref _locationId, -1, id);
        }
    }
}