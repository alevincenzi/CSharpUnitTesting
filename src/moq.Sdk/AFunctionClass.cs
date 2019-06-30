namespace CSharpUnitTesting.moq.Sdk
{
    class AFunctionClass
    {
        private AnInterface _i;

        public AFunctionClass(AnInterface i) => this._i = i;

        public int CallAFunctionWithoutParameters()
        {
            return _i.AFunctionWithoutParameters();
        }

        public int CallAFunctionWithParameter(int param)
        {
            return _i.AFunctionWithParameter(param);
        }
    }
}