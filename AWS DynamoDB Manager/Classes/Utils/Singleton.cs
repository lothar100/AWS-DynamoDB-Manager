using System;

namespace AWS_DynamoDB_Manager.Classes.Utils
{
    public class Singleton<T> where T : class, new()
    {
        public Singleton() { }

        private static Lazy<T> _instance = new Lazy<T>(() => new T());

        public static T Instance { get { return _instance.Value; } }

        public static void Reset()
        {
            _instance = new Lazy<T>(() => new T());
        }
    }
}
