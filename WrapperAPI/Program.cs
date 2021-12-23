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
            // var log =wrapper.Login("Tester33332", "123123");
            // Console.WriteLine(log);
            // Console.WriteLine(wrapper.Registrate("qwertf111", "213123", "strt@sda1111das.ru"));

            Console.WriteLine( wrapper.RefreshToken(
                "def50200ed1c86ea3a69e9956d17cbbd7eb53a2c7b3f8fd0def3bcace89527452d3b6549766e342088d4f093f9fb9de4ef56a3aa05c700ef8648d142be25a45b5a04c757341fad85811831e417b840a91014f5816beb55d913dff1a8dd1106359273df025eec46f64a5957f8e84bedbbf7c285d3177812e1274fd0db7ea5e2ed45d2769b03e5e9020b69c972d11bb8c229572284759be9744ef5a3b3a30efa353ecae51ac62cc86b626d53bcf9b8cfa382f3f0db87370829430c47a76e29588974041c6fb1d9cf87baa06ee831b3f409711460c46620b8e2b3c5c6d71c605cb0bab739cc5c6089557fc819eadeaed0900e3ea2a973a23f5adefd07d7d444237c4880ea079b853a8358a3234ab2bfaf9e2cc47ee3914686ae6675758e19098f7083af251443d978f6a6697e9a9723c1af19f2b13ac94612c7c930c63ae542703b09de9e14f87deddc02058d74e0c6e8a4982174027e5008249d0599822efdc45c0f6005d1a27cfd7573998904e91563"));
        }
    }
}