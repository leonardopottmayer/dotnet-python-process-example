using Newtonsoft.Json;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");

        string pythonExePath = "X:\\Instalados\\Anaconda\\python.exe";
        string scriptPath = "S:\\API\\PythonProcessExample\\PythonProcessExample\\script.py";

        string functionName = "my_function";

        string param1 = "value1";
        string param2 = "value2";

        // Python script will throw an error if this parameters is not empty.
        // It will receive a fifth parameters, but it's waiting for 4 of them.
        //string param3 = "value3";
        string param3 = "";

        string arguments = $"{scriptPath} {functionName} {param1} {param2} {param3}";

        RunScript(pythonExePath, arguments);

        Console.ReadKey();
    }

    static void RunScript(string cmd, string args)
    {
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = cmd;//cmd is full path to python.exe
        start.Arguments = args;//args is path to .py file and any cmd line args
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        using (Process process = Process.Start(start))
        {
            using (StreamReader reader = process.StandardOutput)
            {
                string rawScriptResult = reader.ReadToEnd();

                if (rawScriptResult is null) throw new NotImplementedException("Python script error handling not yet implemented.");

                if (rawScriptResult.Contains("PyScriptError")) throw new NotImplementedException("Python script error handling not yet implemented.");

                MyClass? mappedScriptResult = JsonConvert.DeserializeObject<MyClass>(rawScriptResult);
                Console.WriteLine(rawScriptResult);
            }
        }
    }
}

[Serializable]
public class MyClass
{
    [JsonProperty("param1")]
    public string Param1 { get; set; }

    [JsonProperty("param2")]
    public string Param2 { get; set; }
}