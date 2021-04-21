using System;
using cgds.manufacture.application.Enums;

namespace cgds.manufacture.application.Entities
{
    public class PhotoBookProductType : ProductType
    {
        public override string Description => "Photo book";

        public override decimal PackageWidth => 19;

        public override int StackLimit => 1;

        public override EnumProductType Type => EnumProductType.photoBook;
    }
}
