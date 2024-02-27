using System;

namespace SharpUnit;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class UnitTest : Attribute
{
}
