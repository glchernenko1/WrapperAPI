using System;
using RestSharp.Serialization.Json;


namespace WrapperAPI
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var wrapper = new Wrapper();
            // var tmp = wrapper.Login("Tester33", "123123");
            // Console.WriteLine(tmp);
            var log =wrapper.Login("Tester33332", "123123");
            Console.WriteLine(log);
        }
    }
}