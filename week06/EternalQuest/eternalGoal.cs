class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() => Points;

    public override string GetStatus() => "[~]";

    public override bool IsComplete() => false;

    public override string GetSaveString()
    {
        return $"EternalGoal|{Name}|{Description}|{Points}";
    }
}
