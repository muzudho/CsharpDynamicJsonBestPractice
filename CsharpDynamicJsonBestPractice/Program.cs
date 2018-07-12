using Codeplex.Data;
using CsharpDynamicJsonBestPractice.Model;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace CsharpDynamicJsonBestPractice
{
    /// <summary>
    /// 読むといいもの。
    /// 
    /// JSONを整形するなら。
    /// 2017/09/03「JSON Pretty Linter Ver3」
    /// https://lab.syncer.jp/Tool/JSON-Viewer/
    /// 
    /// デバッグ方法を知るなら。
    /// 03/30/2017「Debugging, Tracing, and Profiling」
    /// https://docs.microsoft.com/en-us/dotnet/framework/debug-trace-profile/
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var json = DynamicJson.Parse(File.ReadAllText("./CsDynamicJsonUsage-config.json"));

                // 連想配列以外の形は取れるはず。
                ConfigModel config = json.Deserialize<ConfigModel>();

                Trace.Listeners.Add(new ConsoleTraceListener());
                Trace.WriteLine($"My name is {config.name}.");
                Trace.WriteLine($"My age is {config.age}.");
                Trace.WriteLine($"My weight is {config.weight}.");

                foreach (string living in config.livingList)
                {
                    Trace.WriteLine($"Living is {living}.");
                }

                foreach (double number in config.lackyNumberList)
                {
                    Trace.WriteLine($"Lacky number is {number}.");
                }

                // 連想配列の形になっている dishMap は、Deserialize では取れない。DynamicJson型から直接取る。
                foreach (string key in json.dishMap.GetDynamicMemberNames())
                {
                    Trace.WriteLine($"ENTRY {key} is {json.dishMap[key]}.");
                }

                ConfigModel.Toy toy = config.toy;
                Trace.WriteLine($"Toy is {toy.name}.");
                Trace.Indent();
                Trace.WriteLine($"Player min is {toy.playerMin}.");
                Trace.WriteLine($"Player max is {toy.playerMax}.");
                Trace.Unindent();
            }
            catch (Exception e)
            {
                Trace.WriteLine($"An error has occurred. {e.Message} {e.StackTrace}");
            }

            Trace.WriteLine("Close this console after 10 seconds.");
            Thread.Sleep(10000);
        }
    }
}
