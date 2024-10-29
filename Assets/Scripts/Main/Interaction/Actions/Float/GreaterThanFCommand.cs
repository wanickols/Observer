public class GreaterThanFCommand : FCommand
{
    public override void checkVal(float val)
    {
        if (val > value)
            Perform();
    }
}
