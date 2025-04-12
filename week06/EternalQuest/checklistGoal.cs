class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        if (_currentCount >= _targetCount)
            return Points + _bonus;
        return Points;
    }

    public override string GetStatus()
    {
        string check = _currentCount >= _targetCount ? "[X]" : "[ ]";
        return $"{check} Completed {_currentCount}/{_targetCount} times";
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetSaveString()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{_targetCount}|{_bonus}|{_currentCount}";
    }
}

