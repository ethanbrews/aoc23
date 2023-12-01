﻿namespace AdventOfCode;

[AttributeUsage(AttributeTargets.Class)]
public class ChallengeNameAttribute(string name) : Attribute
{
    public string Name => name;
}