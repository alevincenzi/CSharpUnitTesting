namespace CSharpUnitTesting.moq.Sdk
{
    class AFunctionClass
    {
        private AnInterface _i;

        public AFunctionClass(AnInterface i) => this._i = i;

        public int Call_ABaseFunction()
        {
            return _i.ABaseFunction();
        }

        public ACustomType Call_ACustomFunction()
        {
            return _i.ACustomFunction();
        }

        public int Call_AFunction(int param)
        {
            return _i.AFunction(param);
        }

        public int Call_AFunctionBaseOut()
        {
            int value = 10;

            _i.AFunctionBaseOut(out value);

            return value;
        }

        public int Call_AFunctionCustomOut()
        {
            var value = new ACustomType(10);

            _i.AFunctionCustomOut(out value);

            return value.Value;
        }

        public int Call_AFunctionBaseRef()
        {
            int value = 10;

            _i.AFunctionBaseRef(ref value);

            return value;
        }

        public int Call_AFunctionCustomRef()
        {
            var value = new ACustomType(10);

            _i.AFunctionCustomRef(ref value);

            return value.Value;
        }
    }
}