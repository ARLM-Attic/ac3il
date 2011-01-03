﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccCIL
{
    public abstract class AccelleratorBase : IAccellerator
    {
        protected abstract object DoAccelerate(string assembly, string methodName, Type returnType = null, params object[] args);

        #region ISPEManager Members

        public abstract void LoadProgram(IEnumerable<ICompiledMethod> methods);

        public abstract object Execute(params object[] arguments);

        public OutType Accelerate<OutType>(Func<OutType> func)
        {
            return (OutType)DoAccelerate(func.Method.Module.Assembly.ManifestModule.Name, func.Method.Name, typeof(OutType));
        }

        public OutType Accelerate<InType, OutType>(Func<InType, OutType> func, InType arg)
        {
            return (OutType)DoAccelerate(func.Method.Module.Assembly.ManifestModule.Name, func.Method.Name, typeof(OutType), arg);
        }

        public OutType Accelerate<InType1, InType2, OutType>(Func<InType1, InType2, OutType> func, InType1 arg1, InType2 arg2)
        {
            return (OutType)DoAccelerate(func.Method.Module.Assembly.ManifestModule.Name, func.Method.Name, typeof(OutType), arg1, arg2);
        }

        public OutType Accelerate<InType1, InType2, InType3, OutType>(Func<InType1, InType2, InType3, OutType> func, InType1 arg1, InType2 arg2, InType3 arg3)
        {
            return (OutType)DoAccelerate(func.Method.Module.Assembly.ManifestModule.Name, func.Method.Name, typeof(OutType), arg1, arg2, arg3);
        }

        public OutType Accelerate<InType1, InType2, InType3, InType4, OutType>(Func<InType1, InType2, InType3, InType4, OutType> func, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4)
        {
            return (OutType)DoAccelerate(func.Method.Module.Assembly.ManifestModule.Name, func.Method.Name, typeof(OutType), arg1, arg2, arg3, arg4);
        }

        public OutType Accelerate<InType1, InType2, InType3, InType4, InType5, OutType>(Func<InType1, InType2, InType3, InType4, InType5, OutType> func, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5)
        {
            return (OutType)DoAccelerate(func.Method.Module.Assembly.ManifestModule.Name, func.Method.Name, typeof(OutType), arg1, arg2, arg3, arg4, arg5);
        }

        public OutType Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, OutType>(Func<InType1, InType2, InType3, InType4, InType5, InType6, OutType> func, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6)
        {
            return (OutType)DoAccelerate(func.Method.Module.Assembly.ManifestModule.Name, func.Method.Name, typeof(OutType), arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public OutType Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, OutType>(Func<InType1, InType2, InType3, InType4, InType5, InType6, InType7, OutType> func, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7)
        {
            return (OutType)DoAccelerate(func.Method.Module.Assembly.ManifestModule.Name, func.Method.Name, typeof(OutType), arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public OutType Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, OutType>(Func<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, OutType> func, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7, InType8 arg8)
        {
            return (OutType)DoAccelerate(func.Method.Module.Assembly.ManifestModule.Name, func.Method.Name, typeof(OutType), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public OutType Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, OutType>(Func<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, OutType> func, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7, InType8 arg8, InType9 arg9)
        {
            return (OutType)DoAccelerate(func.Method.Module.Assembly.ManifestModule.Name, func.Method.Name, typeof(OutType), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }

        public OutType Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, OutType>(Func<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, OutType> func, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7, InType8 arg8, InType9 arg9, InType10 arg10)
        {
            return (OutType)DoAccelerate(func.Method.Module.Assembly.ManifestModule.Name, func.Method.Name, typeof(OutType), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }

        public OutType Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, OutType>(Func<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, OutType> func, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7, InType8 arg8, InType9 arg9, InType10 arg10, InType11 arg11)
        {
            return (OutType)DoAccelerate(func.Method.Module.Assembly.ManifestModule.Name, func.Method.Name, typeof(OutType), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }

        public OutType Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12, OutType>(Func<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12, OutType> func, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7, InType8 arg8, InType9 arg9, InType10 arg10, InType11 arg11, InType12 arg12)
        {
            return (OutType)DoAccelerate(func.Method.Module.Assembly.ManifestModule.Name, func.Method.Name, typeof(OutType), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }

        public OutType Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12, InType13, OutType>(Func<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12, InType13, OutType> func, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7, InType8 arg8, InType9 arg9, InType10 arg10, InType11 arg11, InType12 arg12, InType13 arg13)
        {
            return (OutType)DoAccelerate(func.Method.Module.Assembly.ManifestModule.Name, func.Method.Name, typeof(OutType), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
        }

        public OutType Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12, InType13, InType14, OutType>(Func<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12, InType13, InType14, OutType> func, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7, InType8 arg8, InType9 arg9, InType10 arg10, InType11 arg11, InType12 arg12, InType13 arg13, InType14 arg14)
        {
            return (OutType)DoAccelerate(func.Method.Module.Assembly.ManifestModule.Name, func.Method.Name, typeof(OutType), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
        }

        public OutType Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12, InType13, InType14, InType15, OutType>(Func<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12, InType13, InType14, InType15, OutType> func, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7, InType8 arg8, InType9 arg9, InType10 arg10, InType11 arg11, InType12 arg12, InType13 arg13, InType14 arg14, InType15 arg15)
        {
            return (OutType)DoAccelerate(func.Method.Module.Assembly.ManifestModule.Name, func.Method.Name, typeof(OutType), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
        }

        public OutType Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12, InType13, InType14, InType15, InType16, OutType>(Func<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12, InType13, InType14, InType15, InType16, OutType> func, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7, InType8 arg8, InType9 arg9, InType10 arg10, InType11 arg11, InType12 arg12, InType13 arg13, InType14 arg14, InType15 arg15, InType16 arg16)
        {
            return (OutType)DoAccelerate(func.Method.Module.Assembly.ManifestModule.Name, func.Method.Name, typeof(OutType), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
        }

        public void Accelerate(Action action)
        {
            DoAccelerate(action.Method.Module.Assembly.ManifestModule.Name, action.Method.Name);
        }
        public void Accelerate<InType1>(Action<InType1> action, InType1 arg1)
        {
            DoAccelerate(action.Method.Module.Assembly.ManifestModule.Name, action.Method.Name, null, arg1);
        }

        public void Accelerate<InType1, InType2>(Action<InType1, InType2> action, InType1 arg1, InType2 arg2)
        {
            DoAccelerate(action.Method.Module.Assembly.ManifestModule.Name, action.Method.Name, null, arg1, arg2);
        }

        public void Accelerate<InType1, InType2, InType3>(Action<InType1, InType2, InType3> action, InType1 arg1, InType2 arg2, InType3 arg3)
        {
            DoAccelerate(action.Method.Module.Assembly.ManifestModule.Name, action.Method.Name, null, arg1, arg2, arg3);
        }

        public void Accelerate<InType1, InType2, InType3, InType4>(Action<InType1, InType2, InType3, InType4> action, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4)
        {
            DoAccelerate(action.Method.Module.Assembly.ManifestModule.Name, action.Method.Name, null, arg1, arg2, arg3, arg4);
        }

        public void Accelerate<InType1, InType2, InType3, InType4, InType5>(Action<InType1, InType2, InType3, InType4, InType5> action, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5)
        {
            DoAccelerate(action.Method.Module.Assembly.ManifestModule.Name, action.Method.Name, null, arg1, arg2, arg3, arg4, arg5);
        }

        public void Accelerate<InType1, InType2, InType3, InType4, InType5, InType6>(Action<InType1, InType2, InType3, InType4, InType5, InType6> action, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6)
        {
            DoAccelerate(action.Method.Module.Assembly.ManifestModule.Name, action.Method.Name, null, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public void Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7>(Action<InType1, InType2, InType3, InType4, InType5, InType6, InType7> action, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7)
        {
            DoAccelerate(action.Method.Module.Assembly.ManifestModule.Name, action.Method.Name, null, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public void Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8>(Action<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8> action, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7, InType8 arg8)
        {
            DoAccelerate(action.Method.Module.Assembly.ManifestModule.Name, action.Method.Name, null, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public void Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9>(Action<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9> action, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7, InType8 arg8, InType9 arg9)
        {
            DoAccelerate(action.Method.Module.Assembly.ManifestModule.Name, action.Method.Name, null, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }

        public void Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10>(Action<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10> action, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7, InType8 arg8, InType9 arg9, InType10 arg10)
        {
            DoAccelerate(action.Method.Module.Assembly.ManifestModule.Name, action.Method.Name, null, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }

        public void Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11>(Action<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11> action, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7, InType8 arg8, InType9 arg9, InType10 arg10, InType11 arg11)
        {
            DoAccelerate(action.Method.Module.Assembly.ManifestModule.Name, action.Method.Name, null, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }

        public void Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12>(Action<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12> action, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7, InType8 arg8, InType9 arg9, InType10 arg10, InType11 arg11, InType12 arg12)
        {
            DoAccelerate(action.Method.Module.Assembly.ManifestModule.Name, action.Method.Name, null, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }

        public void Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12, InType13>(Action<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12, InType13> action, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7, InType8 arg8, InType9 arg9, InType10 arg10, InType11 arg11, InType12 arg12, InType13 arg13)
        {
            DoAccelerate(action.Method.Module.Assembly.ManifestModule.Name, action.Method.Name, null, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }

        public void Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12, InType13, InType14>(Action<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12, InType13, InType14> action, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7, InType8 arg8, InType9 arg9, InType10 arg10, InType11 arg11, InType12 arg12, InType13 arg13, InType14 arg14)
        {
            DoAccelerate(action.Method.Module.Assembly.ManifestModule.Name, action.Method.Name, null, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
        }

        public void Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12, InType13, InType14, InType15>(Action<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12, InType13, InType14, InType15> action, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7, InType8 arg8, InType9 arg9, InType10 arg10, InType11 arg11, InType12 arg12, InType13 arg13, InType14 arg14, InType15 arg15)
        {
            DoAccelerate(action.Method.Module.Assembly.ManifestModule.Name, action.Method.Name, null, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
        }

        public void Accelerate<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12, InType13, InType14, InType15, InType16>(Action<InType1, InType2, InType3, InType4, InType5, InType6, InType7, InType8, InType9, InType10, InType11, InType12, InType13, InType14, InType15, InType16> action, InType1 arg1, InType2 arg2, InType3 arg3, InType4 arg4, InType5 arg5, InType6 arg6, InType7 arg7, InType8 arg8, InType9 arg9, InType10 arg10, InType11 arg11, InType12 arg12, InType13 arg13, InType14 arg14, InType15 arg15, InType16 arg16)
        {
            DoAccelerate(action.Method.Module.Assembly.ManifestModule.Name, action.Method.Name, null, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
        }
        #endregion
    }
}
