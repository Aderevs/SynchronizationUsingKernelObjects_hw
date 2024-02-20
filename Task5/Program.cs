namespace Task5
{
    internal class Program
    {
        static Semaphore semaphore = new Semaphore(1, 1, "AccessSemaphore");
        static string fileName = "log.log";
        static void Main(string[] args)
        {
            for (int i = 1; i <= 5; i++)
            {
                Thread thread = new Thread(Worker);
                thread.Start(i);
            }
        }
        static void Worker(object id)
        {
            Console.WriteLine($"Потік {id} намагається отримати доступ до файлу *.log");

            semaphore.WaitOne(); 
            try
            {
                FileInfo file = new FileInfo(fileName);
                using (var stream = file.Open(FileMode.OpenOrCreate))
                {
                    Console.WriteLine($"Потік {id} отримав доступ до файлу *.log");
                    
                    Thread.Sleep(2000);
                    Console.WriteLine($"Потік {id} звільняє доступ до файлу *.log");
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }

            semaphore.Release(); 
        }
    }

}
