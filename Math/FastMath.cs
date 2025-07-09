using System;
using System.Runtime.CompilerServices;


//This is so UNGODLY unsafe that I don't even know if I should use it
public static unsafe class FastMath
{
    public const float PI = 3.1415927f;
    public const float HALF_PI = 1.5707963f;
    public const float TWO_PI = 6.2831855f;
    public const float DEG2RAD = 0.017453292f;
    public const float RAD2DEG = 57.29578f;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float FastSin(float x)
    {
        float x2 = x * x;
        return x * (1.0f - x2 / 6.0f * (1.0f - x2 / 20.0f));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float FastCos(float x)
    {
        float x2 = x * x;
        return 1.0f - x2 / 2.0f * (1.0f - x2 / 12.0f);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float FastTan(float x)
    {
        return FastSin(x) / FastCos(x);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float FastSqrt(float x)
    {
        int i = *(int*)&x;
        i = 0x5f3759df - (i >> 1);
        float y = *(float*)&i;
        return x * y * (1.5f - 0.5f * x * y * y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float FastInvSqrt(float x)
    {
        int i = *(int*)&x;
        i = 0x5f3759df - (i >> 1);
        float y = *(float*)&i;
        return y * (1.5f - 0.5f * x * y * y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float FastPow(float baseVal, float exp)
    {
        int i = *(int*)&baseVal;
        i = (int)(exp * (i - 1064866805) + 1064866805);
        return *(float*)&i;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float FastLog(float x)
    {
        int i = *(int*)&x;
        return (i - 1064866805) * 1.1920929e-7f;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float FastExp(float x)
    {
        int i = (int)(x * 12102203.0f + 1064866805.0f);
        return *(float*)&i;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float FastAbs(float x)
    {
        return x < 0 ? -x : x;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FastMin(int a, int b)
    {
        return a < b ? a : b;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FastMax(int a, int b)
    {
        return a > b ? a : b;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float FastMin(float a, float b)
    {
        return a < b ? a : b;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float FastMax(float a, float b)
    {
        return a > b ? a : b;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FastClamp(int value, int min, int max)
    {
        return value < min ? min : (value > max ? max : value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float FastClamp(float value, float min, float max)
    {
        return value < min ? min : (value > max ? max : value);
    }
}
