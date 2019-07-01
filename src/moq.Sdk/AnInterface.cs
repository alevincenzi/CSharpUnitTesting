namespace CSharpUnitTesting.moq.Sdk
{
    public interface AnInterface
    {
        int ABaseFunction();

        ACustomType ACustomFunction();

        int AFunction(int param);

        void AFunctionBaseOut(out int param);

        void AFunctionCustomOut(out ACustomType param);

        void AFunctionBaseRef(ref int param);

        void AFunctionCustomRef(ref ACustomType param);
    }
}