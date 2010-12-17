﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;

namespace AccCIL
{
    public class AccCIL
    {

        public static List<ICompiledMethod> JIT(IJITCompiler compiler, string assemblyfile)
        {
            if (System.IO.File.Exists(assemblyfile))
            {
                AssemblyDefinition asm = AssemblyFactory.GetAssembly(assemblyfile);
                ModuleDefinition mod = asm.MainModule;

                List<ICompiledMethod> methods = new List<ICompiledMethod>();
                foreach(TypeDefinition tref in mod.Types)
                    foreach (MethodDefinition mdef in tref.Methods)
                    {
                        IR.MethodEntry root = BuildIRTree(mdef);
                        //RegisterAllocator(root);
                        methods.Add(compiler.JIT(root));
                    }

                return methods;
            }
            else
                throw new Exception("Could not find program file: " + assemblyfile);
        }

        public static ICompiledMethod JIT(IJITCompiler compiler, Mono.Cecil.MethodDefinition mdef)
        {
            return compiler.JIT(BuildIRTree(mdef));
        }


        private static void RegisterAllocator(IR.MethodEntry root)
        {
            //Iterate over the independent sub trees
            foreach (IR.InstructionElement el in root.Childnodes)
            {
                //We assume that the output of a tree is a value
                switch (el.Instruction.OpCode.Code)
                {
                    case Mono.Cecil.Cil.Code.Stloc:
                    case Mono.Cecil.Cil.Code.Stloc_0:
                    case Mono.Cecil.Cil.Code.Stloc_1:
                    case Mono.Cecil.Cil.Code.Stloc_2:
                    case Mono.Cecil.Cil.Code.Stloc_3:
                    case Mono.Cecil.Cil.Code.Stloc_S:
                    case Mono.Cecil.Cil.Code.Ret:
                        //We now assign a virtual register for that value,
                        // and pass down the register in the tree to allow sub-operations
                        // inject values into it
                        el.Registers = new IR.VirtualRegister[] { new IR.VirtualRegister() };

                        break;
                    default:
                        throw new Exception("Unexpected code fragment");
                }
            }
        }

        private static void RecursiveRegisterAssigner(IR.InstructionElement el)
        {
            if (el.Childnodes.Length == 1 && NumberOfElementsPoped(el.Instruction.OpCode.StackBehaviourPop) == 1)
            {
            }

            foreach (IR.InstructionElement sel in el.Childnodes)
            {
            }
        }

        private static int NumberOfElementsPoped(Mono.Cecil.Cil.StackBehaviour s, object operand = null)
        {
            switch (s)
            {
                case Mono.Cecil.Cil.StackBehaviour.Pop0:
                    return 0;
                case Mono.Cecil.Cil.StackBehaviour.Pop1:
                case Mono.Cecil.Cil.StackBehaviour.Popi:
                case Mono.Cecil.Cil.StackBehaviour.Popref:
                    return 1;
                case Mono.Cecil.Cil.StackBehaviour.Pop1_pop1:
                case Mono.Cecil.Cil.StackBehaviour.Popi_pop1:
                case Mono.Cecil.Cil.StackBehaviour.Popi_popi:
                case Mono.Cecil.Cil.StackBehaviour.Popi_popi8:
                case Mono.Cecil.Cil.StackBehaviour.Popi_popr4:
                case Mono.Cecil.Cil.StackBehaviour.Popi_popr8:
                case Mono.Cecil.Cil.StackBehaviour.Popref_pop1:
                case Mono.Cecil.Cil.StackBehaviour.Popref_popi:
                    return 2;
                //case Mono.Cecil.Cil.StackBehaviour.Popref_popi_pop1: Hvorfor mangler denne?
                case Mono.Cecil.Cil.StackBehaviour.Popref_popi_popi:
                case Mono.Cecil.Cil.StackBehaviour.Popref_popi_popi8:
                case Mono.Cecil.Cil.StackBehaviour.Popref_popi_popr4:
                case Mono.Cecil.Cil.StackBehaviour.Popref_popi_popr8:
                case Mono.Cecil.Cil.StackBehaviour.Popref_popi_popref:
                    return 3;
                case Mono.Cecil.Cil.StackBehaviour.Varpop:
                    if (operand == null)
                        throw new Exception("This is an unexpected exception");
                    return ((Mono.Cecil.MethodReference)(operand)).Parameters.Count;
                default:
                    throw new InvalidProgramException();
            }
        }

        private static int NumberOfElementsPushed(Mono.Cecil.Cil.StackBehaviour s, object operand = null)
        {
            switch (s)
            {
                case Mono.Cecil.Cil.StackBehaviour.Push0:
                    return 0;
                case Mono.Cecil.Cil.StackBehaviour.Push1_push1:
                    return 2;
                case Mono.Cecil.Cil.StackBehaviour.Push1:
                case Mono.Cecil.Cil.StackBehaviour.Pushi:
                case Mono.Cecil.Cil.StackBehaviour.Pushi8:
                case Mono.Cecil.Cil.StackBehaviour.Pushr4:
                case Mono.Cecil.Cil.StackBehaviour.Pushr8:
                case Mono.Cecil.Cil.StackBehaviour.Pushref:
                    return 1;
                case Mono.Cecil.Cil.StackBehaviour.Varpush:
                    if (operand is Mono.Cecil.MethodReference)
                        return ((Mono.Cecil.MethodReference)(operand)).ReturnType.ReturnType.FullName == "System.Void" ? 0 : 1;
                    else
                        throw new Exception("This is an unexpected exception");
                default:
                    throw new InvalidProgramException();

            }
        }

        private static IR.MethodEntry BuildIRTree(MethodDefinition mdef)
        {
            Stack<IR.InstructionElement> stack = new Stack<IR.InstructionElement>();
            List<IR.InstructionElement> roots = new List<IR.InstructionElement>();

            int returnElements = 1;
            if (mdef.ReturnType.ReturnType.FullName == "System.Void")
                returnElements = 0;

            foreach (Mono.Cecil.Cil.Instruction x in mdef.Body.Instructions)
            {
                IR.InstructionElement[] childnodes;
                if (x.OpCode.Code == Mono.Cecil.Cil.Code.Ret)
                    childnodes = new IR.InstructionElement[returnElements];
                else
                    childnodes = new IR.InstructionElement[NumberOfElementsPoped(x.OpCode.StackBehaviourPop, x.Operand)];

                for (int i = childnodes.Length - 1; i >= 0; i--)
                {
                    System.Diagnostics.Trace.Assert(stack.Count > 0);
                    childnodes[i] = stack.Pop();
                }

                int elementsPushed = NumberOfElementsPushed(x.OpCode.StackBehaviourPush, x.Operand);

                if (elementsPushed == 0)
                {
                    if (stack.Count != 0 && x.OpCode.FlowControl != Mono.Cecil.Cil.FlowControl.Next && x.OpCode.FlowControl != Mono.Cecil.Cil.FlowControl.Call)
                        throw new InvalidProgramException();

                    roots.Add(new IR.InstructionElement(mdef, childnodes, x));
                }
                else
                    stack.Push(new IR.InstructionElement(mdef, childnodes, x));
            }

            if (stack.Count != 0)
                throw new InvalidProgramException();

            return new IR.MethodEntry(mdef) { Childnodes = roots.ToArray() };
        }
    }
}
