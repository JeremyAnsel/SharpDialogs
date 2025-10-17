using System.Runtime.InteropServices;

namespace SharpDialogs.Structures;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct FilterSpec
{
    [MarshalAs(UnmanagedType.LPWStr)]
    public string Name;

    [MarshalAs(UnmanagedType.LPWStr)]
    public string Spec;

    public FilterSpec(string name, string spec)
    {
        Name = name;
        Spec = spec;
    }
}
