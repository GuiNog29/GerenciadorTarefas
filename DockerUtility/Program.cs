using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        ExecuteCommand("docker-compose build");
        ExecuteCommand("docker-compose up -d");
    }

    static void ExecuteCommand(string command)
    {
        var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command)
        {
            RedirectStandardError = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        var process = new Process
        {
            StartInfo = processInfo
        };

        process.OutputDataReceived += (object sender, DataReceivedEventArgs e) => Console.WriteLine("output>>" + e.Data);
        process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) => Console.WriteLine("error>>" + e.Data);
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();
        process.Close();
    }
}
