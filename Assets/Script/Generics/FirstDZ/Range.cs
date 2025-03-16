using System;

[Serializable]
public class Range<T> where T: struct
{
    public T minValue;
    public T maxValue;
}
