using System;
using cgds.manufacture.application.Enums;

namespace cgds.manufacture.application.Entities
{
    public class MugProductType : ProductType
    {

        public override string Description => "Mug";

        public override decimal PackageWidth => 94;

        public override int StackLimit => 4;

        public override EnumProductType Type => EnumProductType.mug;
    }
}
