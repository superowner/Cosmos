﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Cosmos.Compiler.Assembler.X86 {
  public abstract class JumpBase : InstructionWithDestination {
    public string DestinationLabel {
      get {
        if (DestinationRef != null) {
          return DestinationRef.Name;
        }
        return String.Empty;
      }
      set {
        DestinationRef = ElementReference.New(value);
      }
    }
    protected bool mNear = true;
    protected bool mCorrectAddress = true;
    protected virtual bool IsRelativeJump {
      get {
        return true;
      }
    }

    public override void WriteData(Cosmos.Compiler.Assembler.Assembler aAssembler, Stream aOutput) {
      if (mCorrectAddress) {
        if (IsRelativeJump) {
          if (DestinationValue.HasValue && !DestinationIsIndirect) {
            var xCurAddress = ActualAddress;
            var xOrigValue = DestinationValue.Value;
            DestinationValue = (uint)(xOrigValue - xCurAddress.Value);
            try {
              base.WriteData(aAssembler, aOutput);
              return;
            } finally {
              DestinationValue = xOrigValue;
            }
          }
        }
      }
      base.WriteData(aAssembler, aOutput);
    }

  }
}