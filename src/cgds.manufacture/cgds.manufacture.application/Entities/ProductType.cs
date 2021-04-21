using System;
using cgds.manufacture.application.Enums;

namespace cgds.manufacture.application.Entities
{
    public abstract class ProductType
    {
        public abstract EnumProductType Type { get; }
        public abstract string Description { get; }
        public abstract decimal PackageWidth { get; }
        public abstract int StackLimit { get; }
        public bool CanStack { get => StackLimit > 1; }
    }
}