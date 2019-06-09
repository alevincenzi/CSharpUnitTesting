using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CSharpUnitTesting.sdk
{
    class AClassWithProperties : INotifyPropertyChanged
    {
        private int _aValue1;
        private int _aValue2;

        public event PropertyChangedEventHandler PropertyChanged;

        public AClassWithProperties(int value1, int value2)
        {
            _aValue1 = value1;
            _aValue2 = value2;
        } 

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
            =>  PropertyChanged?.Invoke(this, e);

        protected void OnPropertyChanged([CallerMemberName] string name = "")
            => OnPropertyChanged(new PropertyChangedEventArgs(name));

        public int Value1 {
            set {
                if (value != _aValue1)
                {
                    _aValue1 = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Value2 {
            set {
                if (value != _aValue2)
                {
                    _aValue2 = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}