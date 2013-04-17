// Conditional potato cooking
Potato potato;
// ... 
if (potato != null)
{
    if(!potato.IsRotten && potato.HasBeenPeeled)
    {
        Cook(potato);
    }
}


// Conditional cell visit - variant 1
if (IsInRange(x, MIN_X, MAX_X) && IsInRange(y, MIN_Y, MAX_Y) && !visited[x, y])
{
    VisitCell(x, y);
}

// ...

static bool IsInRange(int currentValue, int minValue, int maxValue)
{
    if (currentValue < minValue || maxValue < currentValue)
    {
        return false;
    }

    return true;
}

// Conditional cell visit - variant 2
bool xIsInRange = MIN_X <= x && x <= MAX_X;
bool yIsInRange = MIN_Y <= y && y <= MAX_Y;

if (xIsInRange && yIsInRange && !visited[x, y])
{
    VisitCell(x, y);
}