namespace Challenges.ThreeStacksOneArray;

public class TripleStack
{
    private readonly int[] _array;
    private int _start;
    private int _middleStart;
    private int _middleEnd;
    private int _end;

    public TripleStack(int size)
    {
        _array = new int[size];
        _start = -1;
        _middleStart = size / 3;
        _middleEnd = -1;
        _end = size;
    }
    
    public void PushToStart(int value)
    {
        if (_start + 1 > _array.Length - 1) throw new InvalidOperationException($"Stack is full. {value} at index {_start} could not be added.");
        
        if (_start + 1 < _middleStart)
        {
            _array[++_start] = value;
            return;
        }

        if (_middleEnd == -1)   // middle stack is empty
        {
            _middleStart++;
            PushToStart(value);
            return;
        }

        if (_middleEnd + 1 < _end) 
        {
            for (int i = _middleEnd; i >= _middleStart; i--)
            {
                _array[i + 1] = _array[i];
            }
            _middleStart++;
            _middleEnd++;
            PushToStart(value);
            return;
        }

        throw new InvalidOperationException($"Stack is full. {value} at index {_start} could not be added.");
    }

    public void PushToMiddle(int value)
    {
        var tempMiddleEnd = _middleEnd == -1 ? _middleStart - 1 : _middleEnd;
        if (tempMiddleEnd + 1 > _array.Length - 1) throw new InvalidOperationException("Stack is full.");
        
        if (tempMiddleEnd + 1 < _end)
        {
            _array[++_middleEnd] = value;
            return;
        }
    }

    public void PushToEnd(int value)
    {
        if (_end - 1 < 0) throw new InvalidOperationException("Stack is full.");
        
        if(_end - 1 > _middleEnd && _end - 1 > _middleStart)
        {
            _array[--_end] = value;
            return;
        }

        if (_middleEnd == -1)
        {
            _middleStart--;
            PushToEnd(value);
            return;
        }

        if (_middleStart - 1 > _start)
        {
            for (int i = _middleStart; i <= _middleEnd; i++)
            {
                _array[_middleStart - 1] = _array[_middleStart];
            }
            _middleStart--;
            _middleEnd--;
            PushToEnd(value);
        }
        throw new InvalidOperationException($"Stack is full. {value} at index {_start} could not be added.");
    }

    public int PopFromStart()
    {
        if (_start < 0) throw new InvalidOperationException("Stack is empty.");
        return _array[_start--];
    }
    public void PopFromMiddle(){}

    public int PopFromEnd()
    {
        if(_end > _array.Length - 1) throw new InvalidOperationException("Stack is empty.");
        return _array[_end++];
    }
}