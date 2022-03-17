using AsmJitter;
using AsmJitter.Model;
using AsmJitter.Model.Operand;
using Xunit;

namespace AsmJitterTest;

// Checked with: https://defuse.ca/online-x86-assembler.htm
public class PushTests
{
    [Fact]
    public void TestSimpleRegisterPush()
    {
        var shellcode = new Code();
        shellcode.Push(new EightBitConstant(0));
        var codeBytes = shellcode.GetBytes();
        Assert.Equal(new byte[]
        {
            0x6A, 0x00
        }, codeBytes);
    }

    [Fact]
    public void TestSimpleRegisterPushDuty()
    {
        var shellcode = new Code();
        shellcode.Push(new EightBitConstant(127));
        var codeBytes = shellcode.GetBytes();
        Assert.Equal(new byte[]
        {
            0x6A, 0x7F
        }, codeBytes);
    }
    
    [Fact]
    public void TestSimpleRegisterPushNegativeNumber()
    {
        var shellcode = new Code();
        shellcode.Push(new EightBitConstant(-1));
        var codeBytes = shellcode.GetBytes();
        Assert.Equal(new byte[]
        {
            0x6A, 0xFF
        }, codeBytes);
    }
}