public class LessThanFCommand : FCommand
{
    public override void checkVal(float val)
    {
        if (val < value)
            Perform();
    }
}
