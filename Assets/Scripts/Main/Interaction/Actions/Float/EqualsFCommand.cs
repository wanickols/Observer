public class EqualsFCommand : FCommand
{
    public override void checkVal(float val)
    {
        if (value == val)
            Perform();
    }
}
