using MessageBroker.Kafka.Lib;

namespace NameService
{
    internal class Program
    {
        private static readonly string userHelpMsg = "NameService.\nEnter 'b' or 'g' to process boy or girl names respectively";
        private static readonly string bTopicNameCmd = "b_name_command";
        private static readonly string gTopicNameCmd = "g_name_command";

        private static readonly string bTopicNameResp = "b_name_response";
        private static readonly string gTopicNameResp = "g_name_response";
        private static readonly string[] _boyNames =
        {
            "Arsenii",
            "Igor",
            "Kostya",
            "Ivan",
            "Dmitrii",
        };
        private static readonly string[] _girlNames =
        {
            "Nastya",
            "Lena",
            "Ksusha",
            "Katya",
            "Olga"
        };

        static void Main(string[] args)
        {
            bool canceled = false;

            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                canceled = true;
            };

            using (var msgBus = new MessageBus())
            {
                Console.WriteLine(userHelpMsg);

                HandleUserInput(Console.ReadLine()!, msgBus);

                while (!canceled) { }
            }
        }

        private static void HandleUserInput(string userInput, MessageBus msgBus)
        {
            switch (userInput)
            {
                case "b":
                    Task.Run(() => msgBus.SubscribeOnTopic<string>(bTopicNameCmd, (msg) => BoyNameCommandListener(msg, msgBus), CancellationToken.None));
                    Console.WriteLine("Processing boy names");
                    break;
                case "g":
                    Task gTask = Task.Run(() => msgBus.SubscribeOnTopic<string>(gTopicNameCmd, (msg) => GirlNameCommandListener(msg, msgBus), CancellationToken.None));
                    Console.WriteLine("Processing girl names");
                    break;
                default:
                    Console.WriteLine($"Unknown command. {userHelpMsg}");
                    HandleUserInput(Console.ReadLine()!, msgBus);
                    break;
            }
        }

        private static void BoyNameCommandListener(string msg, MessageBus msgBus)
        {
            Console.WriteLine(msg);
            var r = new Random().Next(0, 5);
            var randName = _boyNames[r];

            msgBus.SendMessage(bTopicNameResp, randName);
            Console.WriteLine($"Sending {randName}");
        }

        private static void GirlNameCommandListener(string msg, MessageBus msgBus)
        {
            var r = new Random().Next(0, 5);
            var randName = _girlNames[r];

            msgBus.SendMessage(gTopicNameResp, randName);
            Console.WriteLine($"Sending {randName}");
        }
    }
}