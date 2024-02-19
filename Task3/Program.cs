namespace Task3
{
    internal class Program
    {
        static Mutex mutex = new Mutex(false, "MyMutex");
        static void Main(string[] args)
        {
            mutex.WaitOne();

            for(int i = 0; i < 20; i++) 
            {
                Console.WriteLine("{0}. Hello, World!", i);
                Thread.Sleep(500);
            }
            mutex.ReleaseMutex();
        }
    }
}
