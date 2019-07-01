namespace CSharpUnitTesting.moq.Sdk
{
    class AFunctionClass
    {
        private AnInterface _i;

        public AFunctionClass(AnInterface i) => this._i = i;

        public int CallABaseFunctionWithoutParameters()
        {
            return _i.ABaseFunctionWithoutParameters();
        }

        public ACustomType CallACustomFunctionWithoutParameters()
        {
            return _i.ACustomFunctionWithoutParameters();
        }

        public int CallAFunctionWithParameter(int param)
        {
            return _i.AFunctionWithParameter(param);
        }

        public int CallAFunctionWithBaseOutParameter()
        {
            int value = 10;

            _i.AFunctionWithBaseOutParameter(out value);

            return value;
        }

        public int CallAFunctionWithCustomOutParameter()
        {
            var value = new ACustomType(10);

            _i.AFunctionWithCustomOutParameter(out value);

            return value.Value;
        }

        public int CallAFunctionWithBaseRefParameter()
        {
            int value = 10;

            _i.AFunctionWithBaseRefParameter(ref value);

            return value;
        }

        public int CallAFunctionWithCustomRefParameter()
        {
            var value = new ACustomType(10);

            _i.AFunctionWithCustomRefParameter(ref value);

            return value.Value;
        }
    }
}