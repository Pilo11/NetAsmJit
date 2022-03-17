using System.Collections.Generic;
using AsmJitter.Model.Operand;

namespace AsmJitter.Model.Instruction;

public class MovRegisterMemoryToRegister : AbstractInstruction
{
    private Register _targetRegister;
    private RegisterMemory _originRegister;

    public MovRegisterMemoryToRegister(Register targetRegister, RegisterMemory originRegister)
    {
        _targetRegister = targetRegister;
        _originRegister = originRegister;
    }

    public override IEnumerable<byte> GetBytes()
    {
        var bytecode = new List<byte>();

        // Add operation byte
        bytecode.Add(Constants.MOV_1632_REGISTER_1632_REGISTERMEMORY);

        // Add register bytes as first operand (origin register as opcode digit) reference: http://ref.x86asm.net/coder32.html#modrm_byte_32
        bytecode.AddRange(_originRegister.GetBytes((uint)_targetRegister.Value));

        return bytecode;
    }
}