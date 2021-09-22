using com.mirle.ibg3k0.bcf.Controller;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Common
{
    public class ObjectPool<T>
    {
        private ConcurrentBag<T> _objects;
        private Func<T> _objectGenerator;

        public ObjectPool(Func<T> objectGenerator)
        {
            if (objectGenerator == null) throw new ArgumentNullException("objectGenerator");
            _objects = new ConcurrentBag<T>();
            _objectGenerator = objectGenerator;
        }

        public T GetObject()
        {

            T item;
            if (_objects.TryTake(out item)) return item;
            Console.WriteLine(_objects.Count());
            return _objectGenerator();
        }

        public void PutObject(T item)
        {
            if (item is List<ValueRead>)
                (item as List<ValueRead>).Clear();
            if (item is List<ValueWrite>)
                (item as List<ValueWrite>).Clear();
            if (item is Dictionary<string, string>)
                (item as Dictionary<string, string>).Clear();
            if (item is StringBuilder)
                (item as StringBuilder).Clear();

            _objects.Add(item);
        }

        public int countAllObjects()
        {
            return _objects.Count();
        }
    }
}