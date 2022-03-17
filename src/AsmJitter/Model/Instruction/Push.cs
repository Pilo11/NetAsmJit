using AsmJitter.Model.Operand;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsmJitter.Model.Instruction
{
    public class Push : AbstractInstruction
    {

        private readonly Register? _register;
        private readonly EightBitConstant? _constant;

        public Push(Register register)
        {
            _register = register;
        }
        
        public Push(EightBitConstant constant)
        {
            _constant = constant;
        }

        public override IEnumerable<byte> GetBytes()
        {
            var bytecode = new List<byte>();
            if (_register != null)
            {
                // Add operation byte
                bytecode.Add(Convert.ToByte(Constants.PUSH_1632_REGISTER + _register.Value));
            }

            if (_constant != null)
            {
                bytecode.Add(Constants.PUSH_CONST_8);
                bytecode.Add((byte)_constant.Value);
            }
            
            return bytecode;
        }

    }
}
