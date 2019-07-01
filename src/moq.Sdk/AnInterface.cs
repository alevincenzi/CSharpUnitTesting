namespace CSharpUnitTesting.moq.Sdk
{
    public interface AnInterface
    {
        int ABaseFunctionWithoutParameters();

        ACustomType ACustomFunctionWithoutParameters();

        int AFunctionWithParameter(int param);

        void AFunctionWithBaseOutParameter(out int param);

        void AFunctionWithCustomOutParameter(out ACustomType param);

        void AFunctionWithBaseRefParameter(ref int param);

        void AFunctionWithCustomRefParameter(ref ACustomType param);
    }
}