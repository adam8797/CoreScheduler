using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CoreScheduler.Client.Desktop.Controls
{
    public class CustomPropertyGrid : PropertyGrid
    {
        private PropertyClass _class;

        public CustomPropertyGrid()
        {
            _class = new PropertyClass();
        }

        protected override void OnCreateControl()
        {
            SelectedObject = _class;
        }

        public void Add<T>(string name, T value, bool readOnly)
        {
            var newProp = new CustomProperty(name, value, typeof(T), readOnly, true);
            _class.Add(newProp);
            Refresh();
        }

        public void Remove(string name)
        {
            _class.Remove(name);
            Refresh();
        }

        public T GetValue<T>(string name)
        {
            return default(T);
        }
    }

    public class CustomProperty
    {
        private readonly string _name;
        private readonly bool _readOnly;
        private readonly bool _visible;
        private readonly Type _type;

        public CustomProperty(string name, object value, Type type, bool readOnly, bool visible)
        {
            _name = name;
            Value = value;
            _type = type;
            _readOnly = readOnly;
            _visible = visible;
        }

        public Type Type
        {
            get { return _type; }
        }

        public bool ReadOnly
        {
            get
            {
                return _readOnly;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public bool Visible
        {
            get
            {
                return _visible;
            }
        }

        public object Value { get; set; }
    }

    public class PropertyClass : CollectionBase, ICustomTypeDescriptor
    {
        public void Add(CustomProperty value)
        {
            List.Add(value);
        }

        /// <summary>
        /// Remove item from List
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {
            foreach (CustomProperty prop in List)
            {
                if (prop.Name == name)
                {
                    List.Remove(prop);
                    return;
                }
            }
        }

        public CustomProperty this[int index]
        {
            get
            {
                return (CustomProperty)List[index];
            }
            set
            {
                List[index] = value;
            }
        }

        #region TypeDescriptor Implementation

        public String GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public String GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            PropertyDescriptor[] newProps = new PropertyDescriptor[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                CustomProperty prop = (CustomProperty)this[i];
                newProps[i] = new CustomPropertyDescriptor(ref prop, attributes);
            }

            return new PropertyDescriptorCollection(newProps);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return TypeDescriptor.GetProperties(this, true);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
        #endregion
    }

    public class CustomPropertyDescriptor : PropertyDescriptor
    {
        private readonly CustomProperty _property;

        public CustomPropertyDescriptor(ref CustomProperty myProperty, Attribute[] attrs) : base(myProperty.Name, attrs)
        {
            _property = myProperty;
        }

        #region PropertyDescriptor specific

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override Type ComponentType
        {
            get { return null; }
        }

        public override object GetValue(object component)
        {
            return _property.Value;
        }

        public override string Description
        {
            get { return _property.Name; }
        }

        public override string Category
        {
            get { return string.Empty; }
        }

        public override string DisplayName
        {
            get { return _property.Name; }
        }

        public override bool IsReadOnly
        {
            get { return _property.ReadOnly; }
        }

        public override void ResetValue(object component)
        {
            //Have to implement
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }

        public override void SetValue(object component, object value)
        {
            _property.Value = value;
        }

        public override Type PropertyType
        {
            get { return _property.Type; }
        }

        #endregion
    }
}
