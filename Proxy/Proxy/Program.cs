using System;

namespace GangOfFour.Proxy.RealWorld
{
    /// The 'Subject interface
    public interface INSC
    {
        string ToBin(int x);
        string ToOct(int x);
        string ToHex(int x);
    }
    /// The 'RealSubject' class
    class NSC : INSC
    {
        public string ToBin(int x) { return Convert.ToString(x, 2); }
        public string ToOct(int x) { return Convert.ToString(x, 8); }
        public string ToHex(int x) { return Convert.ToString(x, 16); }
    }
    /// The 'Proxy Object' class
    class NSCProxy : INSC
    {
        private NSC nsc = new NSC();
        public string ToBin(int x)
        {
            return nsc.ToBin(x);
        }
        public string ToOct(int x)
        {
            return nsc.ToOct(x);
        }
        public string ToHex(int x)
        {
            return nsc.ToHex(x);
        }
    }
    /// MainApp startup class for Real-World 
    /// Proxy Design Pattern.
    class MainApp
    {
        /// Entry point into console application.
        static void Main()
        {
            // Create nsc proxy
            NSCProxy proxy = new NSCProxy();

            // Do the nsc
            Console.WriteLine("123 в двоична е: " + proxy.ToBin(123));
            Console.WriteLine("123 в осмична е:" + proxy.ToOct(123));
            Console.WriteLine("123 в шестнадесетична е:" + proxy.ToHex(123));

            // Wait for user
            Console.ReadKey();
        }
    }
}