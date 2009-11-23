﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmos.IL2CPU.X86.x87
{
    [OpCode("fimul")]
    public class IntMul : InstructionWithDestinationAndSize
    {
        public static void InitializeEncodingData(Instruction.InstructionData aData)
        {
            aData.EncodingOptions.Add(new InstructionData.InstructionEncodingOption
            {
                OpCode = new byte[] { 0xDA },
                NeedsModRMByte=true,
                InitialModRMByteValue=1,
                DestinationImmediate=false,
                DestinationMemory=true,
                DestinationReg=null,
                DefaultSize = InstructionSize.DWord,
                AllowedSizes = InstructionSizes.DWord
            });
            aData.EncodingOptions.Add(new InstructionData.InstructionEncodingOption
            {
                OpCode = new byte[] { 0xDE },
                NeedsModRMByte=true,
                InitialModRMByteValue=1,
                DestinationImmediate = false,
                DestinationMemory = true,
                DestinationReg = null,
                DefaultSize = InstructionSize.Word,
                AllowedSizes = InstructionSizes.Word
            });
        }
    }
}