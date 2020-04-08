namespace CSharpUnitTesting.moq.Sdk
{
    public interface IPropertyType
    {
        int Counter { get; set; }

        int BaseTypeProperty { get; }

        AClassWithProperty CustomTypeProperty { get; }
    }
}